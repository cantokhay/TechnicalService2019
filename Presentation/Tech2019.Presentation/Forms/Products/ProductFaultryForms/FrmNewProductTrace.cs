using System;
using System.Linq;
using System.Windows.Forms;
using Tech2019.DataAccessLayer.Context;
using Tech2019.EntityLayer.Concrete;

namespace Tech2019.Presentation.Forms.Products.ProductFaultryForms
{
    public partial class FrmNewProductTrace : Form
    {
        public FrmNewProductTrace()
        {
            InitializeComponent();
            InitializePlaceholderEvents();
        }

        TechDBContext db = new TechDBContext();

        private void btnNewSave_Click(object sender, EventArgs e)
        {
            if (!ValidateProductTraceInfo())
                return;

            var productTrace = new ProductTrace
            {
                ProductSerialNumber = txtProductSerialNumber.Text,
                ProductTraceDate = DateTime.Parse(txtProductTraceDate.Text),
                ProductTraceInformation = txtProductTraceInformation.Text
            };

            db.ProductTraces.Add(productTrace);
            db.SaveChanges();
            MessageBox.Show("Product trace added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnNewQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnValidSerialNumber_Click(object sender, EventArgs e)
        {
            string serialNumber = txtProductSerialNumber.Text;

            if (!IsValidSerialNumber(serialNumber))
            {
                MessageBox.Show("Invalid product serial number. It must be exactly 5 characters long and include only letters and/or digits.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var serialDetails = (from s in db.Sales
                                 join c in db.Customers on s.Customer equals c.CustomerId
                                 where s.ProductSerialNumber == serialNumber
                                 select new
                                 {
                                     CustomerName = c.CustomerFirstName + " " + c.CustomerLastName,
                                     SaleDate = s.SaleDate
                                 }).FirstOrDefault();

            if (serialDetails != null)
            {
                MessageBox.Show($"Valid Serial Number:\n\n" +
                         $"Customer Name: {serialDetails.CustomerName}\n" +
                         $"Sale Date: {serialDetails.SaleDate.ToShortDateString()}", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("The entered product serial number does not exist in the system or is not associated with any sales.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #region Extracted Methods

        private bool ValidateProductTraceInfo()
        {
            if (!IsValidSerialNumber(txtProductSerialNumber.Text))
            {
                MessageBox.Show("Invalid product serial number. It must be exactly 5 characters long and include only letters and/or digits.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProductSerialNumber.Focus();
                return false;
            }

            if (!db.Actions.Any(a => a.ProductSerialNumber == txtProductSerialNumber.Text))
            {
                MessageBox.Show("The entered product serial number is not associated with any action in the system.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtProductTraceDate.Text) || !DateTime.TryParse(txtProductTraceDate.Text, out _))
            {
                MessageBox.Show("Please provide a valid trace date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProductTraceDate.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtProductTraceInformation.Text) || txtProductTraceInformation.Text == "Trace Information")
            {
                MessageBox.Show("Trace Information cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProductTraceInformation.Focus();
                return false;
            }

            return true;
        }

        private bool IsValidSerialNumber(string serialNumber)
        {
            return !string.IsNullOrWhiteSpace(serialNumber) &&
                   serialNumber.Length == 5 &&
                   serialNumber.All(char.IsLetterOrDigit);
        }

        private void InitializePlaceholderEvents()
        {
            AddPlaceholderEvents(txtProductTraceDate, "Trace Date");
            AddPlaceholderEvents(txtProductSerialNumber, "Product Serial No");
            AddPlaceholderEventsRichTextBox(txtProductTraceInformation, "Trace Information");
        }

        private void AddPlaceholderEvents(DevExpress.XtraEditors.TextEdit textEdit, string placeholder)
        {
            textEdit.GotFocus += (sender, e) =>
            {
                if (textEdit.Text == placeholder)
                    textEdit.Text = string.Empty;
            };

            textEdit.LostFocus += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(textEdit.Text))
                    textEdit.Text = placeholder;
            };
        }

        private void AddPlaceholderEventsRichTextBox(RichTextBox richTextBox, string placeholder)
        {
            richTextBox.Enter += (sender, e) =>
            {
                if (richTextBox.Text == placeholder)
                    richTextBox.Text = string.Empty;
            };

            richTextBox.Leave += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(richTextBox.Text))
                    richTextBox.Text = placeholder;
            };
        }

        #endregion
    }
}
