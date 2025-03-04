using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Tech2019.BusinessLayer.AbstractServices;
using Tech2019.EntityLayer.Concrete;
using Tech2019.EntityLayer.Enum;

namespace Tech2019.Presentation.Forms.Customers.CustomerCustomerForms
{
    public partial class FrmNewCustomer : Form
    {
        private readonly ICustomerService _customerService;
        public FrmNewCustomer(ICustomerService customerService)
        {
            _customerService = customerService;
            InitializeComponent();
        }
        private void FrmNewCustomer_Load(object sender, EventArgs e)
        {
            FillLookUpEditCustomerStatusCitiesandDistricts();
            InitializePlaceholderEvents();
        }

        private void btnNewQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNewSave_Click(object sender, EventArgs e)
        {
            if (!ValidateCustomerInfo())
                return;

            Customer customer = new Customer();
            AssignCustomerInfo(customer);
            _customerService.Create(customer);
            MessageBox.Show("Customer added successfully");
            this.Close();
        }

        #region Extracted Methods

        private void FillLookUpEditCustomerStatusCitiesandDistricts()
        {
            lueCustomerCity.Properties.DataSource = _customerService.GetDistinctCityList();
            lueCustomerCity.Properties.NullText = "Please pick a city";
            lueCustomerDistrict.Properties.DataSource = _customerService.GetDistinctDistrictList();
            lueCustomerDistrict.Properties.NullText = "Please pick a district";

            var customerStatusList = Enum.GetValues(typeof(CustomerStatus))
                .Cast<CustomerStatus>()
                .Select(status => new
                {
                    StatusValues = (int)status,
                    StatusDisplays = status.ToString()
                })
                .ToList();

            lueCustomerStatus.Properties.DataSource = customerStatusList;
            lueCustomerStatus.Properties.DisplayMember = "StatusDisplays";
            lueCustomerStatus.Properties.ValueMember = "StatusValues";
            lueCustomerStatus.Properties.NullText = "Please pick a customer status";
        }

        private void AssignCustomerInfo(Customer customer)
        {
            customer.CustomerFirstName = txtCustomerFirstName.Text;
            customer.CustomerLastName = txtCustomerLastName.Text;
            customer.CustomerEmail = txtCustomerEmail.Text;
            customer.CustomerPhoneNumber = txtCustomerPhone.Text;
            customer.CustomerAddress = txtCustomerAddress.Text;
            customer.CustomerStatus = (CustomerStatus)Enum.Parse(typeof(CustomerStatus), lueCustomerStatus.EditValue.ToString());
            customer.CustomerTaxNumber = txtCustomerTaxNumber.Text;
            customer.CustomerTaxOffice = txtCustomerTaxOffice.Text;
            customer.CustomerBank = txtCustomerBank.Text;
            customer.CustomerCity = lueCustomerCity.EditValue.ToString();
            customer.CustomerDistrict = lueCustomerDistrict.EditValue.ToString();
        }

        private bool ValidateCustomerInfo()
        {
            if (string.IsNullOrWhiteSpace(txtCustomerFirstName.Text) || txtCustomerFirstName.Text == "Customer First Name")
            {
                MessageBox.Show("First Name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtCustomerLastName.Text) || txtCustomerLastName.Text == "Customer Last Name")
            {
                MessageBox.Show("Last Name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtCustomerPhone.Text) || txtCustomerPhone.Text == "Customer Phone Number")
            {
                MessageBox.Show("Phone Number cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtCustomerEmail.Text) || txtCustomerEmail.Text == "Customer Email")
            {
                MessageBox.Show("Email cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (lueCustomerCity.EditValue == null)
            {
                MessageBox.Show("Please select a City.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (lueCustomerDistrict.EditValue == null)
            {
                MessageBox.Show("Please select a District.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtCustomerBank.Text) || txtCustomerBank.Text == "Bank")
            {
                MessageBox.Show("Bank cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtCustomerTaxOffice.Text) || txtCustomerTaxOffice.Text == "Tax Office")
            {
                MessageBox.Show("Tax Office cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtCustomerTaxNumber.Text) || txtCustomerTaxNumber.Text == "Tax Number")
            {
                MessageBox.Show("Tax Number cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (lueCustomerStatus.EditValue == null)
            {
                MessageBox.Show("Please select a status for this customer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtCustomerAddress.Text) || txtCustomerAddress.Text == "Address")
            {
                MessageBox.Show("Address cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void InitializePlaceholderEvents()
        {
            AddPlaceholderEvents(txtCustomerFirstName, "Customer First Name");
            AddPlaceholderEvents(txtCustomerLastName, "Customer Last Name");
            AddPlaceholderEvents(txtCustomerPhone, "Customer Phone Number");
            AddPlaceholderEvents(txtCustomerEmail, "Customer Email");
            AddPlaceholderEvents(txtCustomerBank, "Bank");
            AddPlaceholderEvents(txtCustomerTaxOffice, "Tax Office");
            AddPlaceholderEvents(txtCustomerTaxNumber, "Tax Number");
            AddPlaceholderEvents(txtCustomerAddress, "Address");
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
