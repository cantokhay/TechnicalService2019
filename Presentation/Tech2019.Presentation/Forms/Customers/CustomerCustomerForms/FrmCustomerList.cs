using System;
using System.Linq;
using System.Windows.Forms;
using Tech2019.BusinessLayer.AbstractServices;
using Tech2019.EntityLayer.Concrete;
using Tech2019.EntityLayer.Enum;

namespace Tech2019.Presentation.Forms.Customers.CustomerCustomerForms
{
    public partial class FrmCustomerList : Form
    {
        private readonly ICustomerService _customerService;

        public FrmCustomerList(ICustomerService customerService)
        {
            _customerService = customerService;
            InitializeComponent();
        }

        private void FrmCustomerList_Load(object sender, System.EventArgs e)
        {
            LoadCustomerList();
            FillLookUpEditCustomerStatusCitiesandDistricts();
            ClearCustomerInfo();
            ShowStatsByLinq();
        }

        private void gvwCustomers_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtCustomerId.Text = gvwCustomers.GetFocusedRowCellValue("CustomerId").ToString();
            txtCustomerFirstName.Text = gvwCustomers.GetFocusedRowCellValue("CustomerFirstName").ToString();
            txtCustomerLastName.Text = gvwCustomers.GetFocusedRowCellValue("CustomerLastName").ToString();
            txtEmail.Text = gvwCustomers.GetFocusedRowCellValue("CustomerEmail").ToString();
            txtPhoneNumber.Text = gvwCustomers.GetFocusedRowCellValue("CustomerPhoneNumber").ToString();
            txtAddress.Text = gvwCustomers.GetFocusedRowCellValue("CustomerAddress").ToString();
            var customerStatusValue = gvwCustomers.GetFocusedRowCellValue("CustomerStatus");
            lueCustomerStatus.EditValue = (int)Enum.Parse(typeof(CustomerStatus), customerStatusValue.ToString());
            txtTaxNumber.Text = gvwCustomers.GetFocusedRowCellValue("CustomerTaxNumber").ToString();
            txtTaxOffice.Text = gvwCustomers.GetFocusedRowCellValue("CustomerTaxOffice").ToString();
            txtBank.Text = gvwCustomers.GetFocusedRowCellValue("CustomerBank").ToString();
            lueCustomerCity.EditValue = gvwCustomers.GetFocusedRowCellValue("CustomerCity").ToString();
            lueCustomerDistrict.EditValue = gvwCustomers.GetFocusedRowCellValue("CustomerDistrict").ToString();
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            if (!ValidateCustomerInfo())
                return;

            Customer customer = new Customer();
            AssignCustomerInfo(customer);
            _customerService.Create(customer);
            MessageBox.Show("Customer Added Successfully", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadCustomerList();
            ClearCustomerInfo();
        }

        private void btnDelete_Click(object sender, System.EventArgs e)
        {
            if (!ValidateCustomerId())
                return;

            int id = int.Parse(txtCustomerId.Text);
            var customer = _customerService.GetById(id);
            _customerService.Delete(customer);
            MessageBox.Show("Customer Deleted", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            LoadCustomerList();
            ClearCustomerInfo();
        }

        private void btnUpdate_Click(object sender, System.EventArgs e)
        {
            if (!ValidateCustomerId())
                return;

            if (!ValidateCustomerInfo())
                return;

            int id = int.Parse(txtCustomerId.Text);
            var customer = _customerService.GetById(id);
            AssignCustomerInfo(customer);
            _customerService.Update(customer);
            MessageBox.Show("Customer Updated", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            LoadCustomerList();
            ClearCustomerInfo();
        }

        private void btnRefresh_Click(object sender, System.EventArgs e)
        {
            LoadCustomerList();
            ClearCustomerInfo();
            ShowStatsByLinq();
        }

        #region Extracted Methods

        private void ClearCustomerInfo()
        {
            txtCustomerId.Text = string.Empty;
            txtCustomerFirstName.Text = string.Empty;
            txtCustomerLastName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtPhoneNumber.Text = string.Empty;
            lueCustomerStatus.EditValue = null;
            txtTaxNumber.Text = string.Empty;
            txtTaxOffice.Text = string.Empty;
            txtBank.Text = string.Empty;
            lueCustomerCity.EditValue = null;
            lueCustomerDistrict.EditValue = null;
        }

        private void ShowStatsByLinq()
        {
            lblTotalCustomerStat.Text = _customerService.GetTotalCustomerCount().ToString();
            lblActiveCustomerStat.Text = _customerService.GetTotalActiveBuyerCount().ToString();
            lblMostCustomerByCityStat.Text = _customerService.GetMostCustomerCityName();
            lblTotalCitiesStat.Text = _customerService.GetTotalDistinctCityCount().ToString();
        }

        private void FillLookUpEditCustomerStatusCitiesandDistricts()
        {
            lueCustomerCity.Properties.DataSource = _customerService.GetDistinctCityList();
            lueCustomerCity.Properties.NullText = "Please pick a value";
            lueCustomerDistrict.Properties.DataSource = _customerService.GetDistinctDistrictList();
            lueCustomerDistrict.Properties.NullText = "Please pick a value";

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
            lueCustomerStatus.Properties.NullText = "Please pick a value";
        }

        private void LoadCustomerList()
        {
            var customerList = _customerService.GetCustomers();
            grcCustomerList.DataSource = customerList;
        }

        private void AssignCustomerInfo(Customer customer)
        {
            customer.CustomerFirstName = txtCustomerFirstName.Text;
            customer.CustomerLastName = txtCustomerLastName.Text;
            customer.CustomerEmail = txtEmail.Text;
            customer.CustomerPhoneNumber = txtPhoneNumber.Text;
            customer.CustomerAddress = txtAddress.Text;
            customer.CustomerStatus = (CustomerStatus)Enum.Parse(typeof(CustomerStatus), lueCustomerStatus.EditValue.ToString());
            customer.CustomerTaxNumber = txtTaxNumber.Text;
            customer.CustomerTaxOffice = txtTaxOffice.Text;
            customer.CustomerBank = txtBank.Text;
            customer.CustomerCity = lueCustomerCity.EditValue.ToString();
            customer.CustomerDistrict = lueCustomerDistrict.EditValue.ToString();
        }

        #endregion

        #region Validation Methods

        private bool ValidateCustomerInfo()
        {
            if (string.IsNullOrWhiteSpace(txtCustomerFirstName.Text))
            {
                MessageBox.Show("First Name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtCustomerLastName.Text))
            {
                MessageBox.Show("Last Name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtPhoneNumber.Text))
            {
                MessageBox.Show("Phone Number cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
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
            if (string.IsNullOrWhiteSpace(txtBank.Text))
            {
                MessageBox.Show("Bank cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtTaxOffice.Text))
            {
                MessageBox.Show("Tax Office cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtTaxNumber.Text))
            {
                MessageBox.Show("Tax Number cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (lueCustomerStatus.EditValue == null)
            {
                MessageBox.Show("Please select a status for this customer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("Address cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private bool ValidateCustomerId()
        {
            if (string.IsNullOrWhiteSpace(txtCustomerId.Text))
            {
                MessageBox.Show("Customer ID cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!int.TryParse(txtCustomerId.Text, out _))
            {
                MessageBox.Show("Customer ID must be a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        #endregion

    }
}
