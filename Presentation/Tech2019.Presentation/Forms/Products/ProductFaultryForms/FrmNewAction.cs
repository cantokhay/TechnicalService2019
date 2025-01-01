using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Tech2019.DataAccessLayer.Context;

namespace Tech2019.Presentation.Forms.Products.ProductFaultryForms
{
    public partial class FrmNewAction : Form
    {
        public FrmNewAction()
        {
            InitializeComponent();
            InitializePlaceholderEvents();
            FillLookUpEditCustomerEmployee();
        }

        TechDBContext db = new TechDBContext();

        private void btnNewSave_Click(object sender, EventArgs e)
        {
            if (!ValidateActionInfo())
                return;

            EntityLayer.Concrete.Action action = new EntityLayer.Concrete.Action();
            AssignActionInfo(action);
            db.Actions.Add(action);
            db.SaveChanges();
            MessageBox.Show("Action added successfully");
            this.Close();
        }

        private void btnNewQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGetCustomerInfo_Click(object sender, EventArgs e)
        {
            if (!IsValidSerialNumber(txtProductSerialNumber.Text))
            {
                MessageBox.Show("Product serial number must be exactly 5 characters long and include only letters and/or digits.",
                                "Invalid Input",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                txtProductSerialNumber.Text = string.Empty;
                txtProductSerialNumber.Focus();
                return;
            }

            var sale = (from s in db.Sales
                        join c in db.Customers on s.Customer equals c.CustomerId
                        where s.ProductSerialNumber == txtProductSerialNumber.Text
                        select new
                        {
                            s.Customer,
                            c.CustomerFirstName,
                            c.CustomerLastName,
                            s.SaleDate
                        }).FirstOrDefault();

            if (sale != null)
            {
                MessageBox.Show($"Customer information retrieved successfully:\n\n" +
                                $"Customer ID: {sale.Customer}\n" +
                                $"Customer Name: {sale.CustomerFirstName} {sale.CustomerLastName}\n" +
                                $"Sale Date: {sale.SaleDate.ToShortDateString()}\n",
                                "Valid Serial Number",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No sale found for the provided product serial number.",
                                "No Data Found",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
        }


        #region Extracted Methods
        private bool ValidateActionInfo()
        {
            if (lueCustomers.EditValue == null)
            {
                MessageBox.Show("Please select a customer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lueCustomers.Focus();
                return false;
            }

            if (lueEmployees.EditValue == null)
            {
                MessageBox.Show("Please select an employee.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lueEmployees.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtAcceptedDate.Text) || !DateTime.TryParse(txtAcceptedDate.Text, out _) || txtAcceptedDate.Text == "Accepted Date")
            {
                MessageBox.Show("Please provide a valid accepted date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAcceptedDate.Focus();
                return false;
            }

            if (!IsValidSerialNumber(txtProductSerialNumber.Text) || txtProductSerialNumber.Text == "Product Serial No")
            {
                MessageBox.Show("Product serial number must be exactly 5 characters long and include only letters and/or digits.",
                                "Invalid Input",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                txtProductSerialNumber.Focus();
                return false;
            }
            return true;
        }

        private void FillLookUpEditCustomerEmployee()
        {
            var customersList = db.Customers.Select(x => new
            {
                x.CustomerId,
                Customer = x.CustomerFirstName + " " + x.CustomerLastName,
            }).ToList();
            lueCustomers.Properties.DataSource = customersList;
            lueCustomers.Properties.NullText = "Please pick a value";

            var employeesList = db.Employees.Select(x => new
            {
                x.EmployeeId,
                Employee = x.EmployeeFirstName + " " + x.EmployeeLastName
            }).ToList();
            lueEmployees.Properties.DataSource = employeesList;
            lueEmployees.Properties.NullText = "Please pick a value";
        }

        private void AssignActionInfo(EntityLayer.Concrete.Action action)
        {
            action.Employee = short.Parse(lueEmployees.EditValue.ToString());
            action.Customer = int.Parse(lueCustomers.EditValue.ToString());
            action.AcceptedDate = DateTime.Parse(txtAcceptedDate.Text);
            action.ProductSerialNumber = txtProductSerialNumber.Text;
        }

        private bool IsValidSerialNumber(string serialNumber)
        {
            return serialNumber.Length == 5 && serialNumber.All(char.IsLetterOrDigit);
        }

        private void InitializePlaceholderEvents()
        {
            AddPlaceholderEvents(txtAcceptedDate, "Accepted Date");
            AddPlaceholderEvents(txtProductSerialNumber, "Product Serial No");
        }

        private void AddPlaceholderEvents(DevExpress.XtraEditors.TextEdit textEdit, string placeholder)
        {
            textEdit.GotFocus += (sender, e) =>
            {
                if (textEdit.Text == placeholder)
                {
                    textEdit.Text = string.Empty;
                }
            };

            textEdit.LostFocus += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(textEdit.Text))
                {
                    textEdit.Text = placeholder;
                }
            };
        }

        #endregion
    }
}
