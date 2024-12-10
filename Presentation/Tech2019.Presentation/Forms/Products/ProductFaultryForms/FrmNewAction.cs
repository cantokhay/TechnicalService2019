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
            FillLookUpEditCustomerEmployee();
        }

        TechDBContext db = new TechDBContext();

        private void btnNewSave_Click(object sender, EventArgs e)
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

            var sale = db.Sales.FirstOrDefault(s => s.ProductSerialNumber == txtProductSerialNumber.Text);

            if (sale != null)
            {
                lueCustomers.EditValue = sale.Customer;
                MessageBox.Show($"Customer information retrieved successfully:\n\n" +
                                $"Customer ID: {sale.Customer}\n" +
                                $"Sale Date: {sale.SaleDate.ToShortDateString()}\n",
                                "Information",
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

        private void FillLookUpEditCustomerEmployee()
        {
            var customersList = db.Customers.Select(x => new
            {
                x.CustomerId,
                Customer = x.CustomerFirstName + " " + x.CustomerLastName,
            }).ToList();
            lueCustomers.Properties.DataSource = customersList;

            var employeesList = db.Employees.Select(x => new
            {
                x.EmployeeId,
                Employee = x.EmployeeFirstName + " " + x.EmployeeLastName
            }).ToList();
            lueEmployees.Properties.DataSource = employeesList;
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

        #endregion
    }
}
