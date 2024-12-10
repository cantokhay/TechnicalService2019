using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Tech2019.DataAccessLayer.Context;
using Tech2019.EntityLayer.Concrete;

namespace Tech2019.Presentation.Forms.Customers.CustomerSaleForms
{
    public partial class FrmNewSale : Form
    {
        public FrmNewSale()
        {
            InitializeComponent();
            FillLookUpEditProductCustomerEmployee();
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
            Sale sale = new Sale();
            AssignSaleInfo(sale);
            db.Sales.Add(sale);
            db.SaveChanges();
            MessageBox.Show("Sale added successfully");
            this.Close();
        }

        private void btnNewQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Extracted Methods

        private void FillLookUpEditProductCustomerEmployee()
        {
            var productsList = db.Products.Select(x => new
            {
                x.ProductId,
                x.ProductName
            }).ToList();
            lueProducts.Properties.DataSource = productsList;

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

        private void AssignSaleInfo(Sale sale)
        {
            sale.Product = int.Parse(lueProducts.EditValue.ToString());
            sale.Customer = int.Parse(lueCustomers.EditValue.ToString());
            sale.Employee = short.Parse(lueEmployees.EditValue.ToString());
            sale.SaleDate = DateTime.Parse(txtSaleDate.Text);
            sale.SaleQuantity = short.Parse(numSaleQuantity.Text);
            sale.SaleTotalPrice = decimal.Parse(txtSalePrice.Text);
            sale.ProductSerialNumber = txtProductSerialNumber.Text;
        }

        private bool IsValidSerialNumber(string serialNumber)
        {
            return serialNumber.Length == 5 && serialNumber.All(char.IsLetterOrDigit);
        }

        #endregion
    }
}
