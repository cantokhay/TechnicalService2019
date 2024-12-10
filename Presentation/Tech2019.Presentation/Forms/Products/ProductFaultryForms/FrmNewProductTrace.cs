using System;
using System.Data;
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
        }

        TechDBContext db = new TechDBContext();

        private void btnNewSave_Click(object sender, EventArgs e)
        {
            if (!ValidateAndHandleSerialNumber(txtProductSerialNumber.Text))
                return;

            ProductTrace productTrace = new ProductTrace();
            AssignProductTraceInfo(productTrace);
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
            ValidateAndHandleSerialNumber(txtProductSerialNumber.Text);
        }

        #region Extracted Methods

        private void AssignProductTraceInfo(ProductTrace productTrace)
        {
            productTrace.ProductSerialNumber = txtProductSerialNumber.Text;
            productTrace.ProductTraceDate = DateTime.Parse(txtProductTraceDate.Text);
            productTrace.ProductTraceInformation = txtProductTraceInformation.Text;
        }

        private bool ValidateAndHandleSerialNumber(string serialNumber)
        {
            if (!IsValidSerialNumber(serialNumber))
            {
                MessageBox.Show("Product serial number must be exactly 5 characters long and include only letters and/or digits.",
                                "Invalid Input",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                txtProductSerialNumber.Text = string.Empty;
                txtProductSerialNumber.Focus();
                return false;
            }

            bool serialExists = db.Actions.Any(a => a.ProductSerialNumber == serialNumber);

            if (serialExists)
            {
                var serialDetails = db.Sales
                    .Where(a => a.ProductSerialNumber == serialNumber)
                    .Select(a => new
                    {
                        CustomerFullName = a.CustomerNavigation.CustomerFirstName + " " + a.CustomerNavigation.CustomerLastName,
                        a.SaleDate
                    })
                    .FirstOrDefault();

                MessageBox.Show($"The entered product serial number is sold by us AND!\n" +
                                     $"Aftersale action has been saved on our system\n" +
                                $"Customer Name: {serialDetails.CustomerFullName}\n" +
                                $"Sale Date: {serialDetails.SaleDate:dd-MM-yyyy}",
                                "Valid Serial Number",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return true;
            }
            else
            {
                MessageBox.Show("The entered product serial number does not have any aftersale action.",
                                "Invalid Serial Number",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                txtProductSerialNumber.Text = string.Empty;
                txtProductSerialNumber.Focus();
                return false;
            }
        }

        private bool IsValidSerialNumber(string serialNumber)
        {
            return serialNumber.Length == 5 && serialNumber.All(char.IsLetterOrDigit);
        }

        #endregion
    }
}
