using System;
using System.Linq;
using System.Windows.Forms;
using Tech2019.BusinessLayer.AbstractServices;
using Tech2019.EntityLayer.Concrete;

namespace Tech2019.Presentation.Forms.Customers.CustomerSaleForms
{
    public partial class FrmNewSale : Form
    {
        private readonly ISaleService _saleService;
        private readonly ICustomerService _customerService;
        private readonly IEmployeeService _employeeService;
        private readonly IProductService _productService;

        public FrmNewSale(ISaleService saleService, ICustomerService customerService, IEmployeeService employeeService, IProductService productService)
        {
            _saleService = saleService;
            _customerService = customerService;
            _employeeService = employeeService;
            _productService = productService;
            InitializeComponent();
        }
        private void FrmNewSale_Load(object sender, EventArgs e)
        {
            FillLookUpEditProductCustomerEmployee();
            InitializePlaceholderEvents();
        }

        private void btnNewSave_Click(object sender, EventArgs e)
        {
            if (!ValidateSaleInfo())
                return;

            Sale sale = new Sale();
            AssignSaleInfo(sale);
            _saleService.Create(sale);
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
            var products = _productService.GetProductsToSale();
            lueProducts.Properties.DataSource = products;
            lueProducts.Properties.DisplayMember = "ProductName";
            lueProducts.Properties.ValueMember = "ProductId"; 
            lueProducts.Properties.NullText = "Please pick a product";

            var customers = _customerService.GetCustomersToSale();
            lueCustomers.Properties.DataSource = customers;
            lueCustomers.Properties.DisplayMember = "CustomerFullName";
            lueCustomers.Properties.ValueMember = "CustomerId";
            lueCustomers.Properties.NullText = "Please pick a customer";

            var employees = _employeeService.GetEmployeesToSale();
            lueEmployees.Properties.DataSource = employees;
            lueEmployees.Properties.DisplayMember = "EmployeeFullName";
            lueEmployees.Properties.ValueMember = "EmployeeId";
            lueEmployees.Properties.NullText = "Please pick an employee";
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

        private bool ValidateSaleInfo()
        {
            if (lueProducts.EditValue == null)
            {
                MessageBox.Show("Please select a product.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lueProducts.Focus();
                return false;
            }

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

            if (string.IsNullOrWhiteSpace(txtSaleDate.Text) || !DateTime.TryParse(txtSaleDate.Text, out _) || txtSaleDate.Text == "Sale Date")
            {
                MessageBox.Show("Please provide a valid sale date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSaleDate.Focus();
                return false;
            }

            if (numSaleQuantity.Value <= 0)
            {
                MessageBox.Show("Sale quantity must be greater than 0.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numSaleQuantity.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSalePrice.Text) || !decimal.TryParse(txtSalePrice.Text, out _) || txtSalePrice.Text == "Sale Price")
            {
                MessageBox.Show("Please provide a valid sale price.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSalePrice.Focus();
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

        private void InitializePlaceholderEvents()
        {
            AddPlaceholderEvents(txtSaleDate, "Sale Date");
            AddPlaceholderEvents(txtSalePrice, "Sale Price");
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
