using System.Data;
using System.Linq;
using System.Windows.Forms;
using Tech2019.DataAccessLayer.Context;
using Tech2019.EntityLayer.Concrete;

namespace Tech2019.Presentation.Forms.Customers.CustomerCustomerForms
{
    public partial class FrmCustomerList : Form
    {
        public FrmCustomerList()
        {
            InitializeComponent();
        }

        TechDBContext db = new TechDBContext();

        private void FrmCustomerList_Load(object sender, System.EventArgs e)
        {
            CustomerList();
            FillLookUpEditCitiesandDistricts();
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
            txtStatus.Text = gvwCustomers.GetFocusedRowCellValue("CustomerStatus").ToString();
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
            db.Customers.Add(customer);
            db.SaveChanges();
            MessageBox.Show("Customer Added Successfully", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CustomerList();
            ClearCustomerInfo();
        }

        private void btnDelete_Click(object sender, System.EventArgs e)
        {
            if (!ValidateCustomerId())
                return;

            int id = int.Parse(txtCustomerId.Text);
            var customer = db.Customers.Find(id);

            if (customer == null)
            {
                MessageBox.Show("Customer Not Found", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            db.Customers.Remove(customer);
            db.SaveChanges();
            MessageBox.Show("Customer Deleted", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            CustomerList();
            ClearCustomerInfo();
        }

        private void btnUpdate_Click(object sender, System.EventArgs e)
        {
            if (!ValidateCustomerId())
                return;

            if (!ValidateCustomerInfo())
                return;

            int id = int.Parse(txtCustomerId.Text);
            var customer = db.Customers.Find(id);

            if (customer == null)
            {
                MessageBox.Show("Customer Not Found", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            AssignCustomerInfo(customer);
            db.SaveChanges();
            MessageBox.Show("Customer Updated", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            CustomerList();
            ClearCustomerInfo();
        }

        private void btnRefresh_Click(object sender, System.EventArgs e)
        {
            CustomerList();
            ClearCustomerInfo();
            ShowStatsByLinq();
        }

        #region Extracted Methods

        private void ShowStatsByLinq()
        {
            lblTotalProductStat.Text = db.Customers.Count().ToString();
            lblActiveCustomerStat.Text = db.Customers.Where(c => c.CustomerStatus == "True").Count().ToString();
            lblMostCustomerByCityStat.Text = db.Customers.GroupBy(c => c.CustomerCity).OrderByDescending(c => c.Count()).Select(c => c.Key).FirstOrDefault();
            lblTotalCitiesStat.Text = db.Customers.Select(c => c.CustomerCity).Distinct().Count().ToString();
        }

        private void ClearCustomerInfo()
        {
            txtCustomerId.Text = string.Empty;
            txtCustomerFirstName.Text = string.Empty;
            txtCustomerLastName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtPhoneNumber.Text = string.Empty;
            txtStatus.Text = string.Empty;
            txtTaxNumber.Text = string.Empty;
            txtTaxOffice.Text = string.Empty;
            txtBank.Text = string.Empty;
            lueCustomerCity.EditValue = null;
            lueCustomerDistrict.EditValue = null;
        }

        private void FillLookUpEditCitiesandDistricts()
        {
            lueCustomerCity.Properties.DataSource = db.Customers.Select(c => c.CustomerCity).Distinct().ToList();
            lueCustomerCity.Properties.NullText = "Please pick a value";
            lueCustomerDistrict.Properties.DataSource = db.Customers.Select(c => c.CustomerDistrict).Distinct().ToList();
            lueCustomerDistrict.Properties.NullText = "Please pick a value";
            var districts = db.Customers.Select(c => c.CustomerDistrict).Distinct().ToList();
            lueCustomerDistrict.Properties.DataSource = districts;
        }

        private void CustomerList()
        {
            var customerList = db.Customers.Select(c => new
            {
                c.CustomerId,
                c.CustomerFirstName,
                c.CustomerLastName,
                c.CustomerEmail,
                c.CustomerPhoneNumber,
                c.CustomerAddress,
                c.CustomerStatus,
                c.CustomerTaxNumber,
                c.CustomerTaxOffice,
                c.CustomerBank,
                c.CustomerCity,
                c.CustomerDistrict
            }).ToList();
            grcCustomerList.DataSource = customerList;
        }

        private void AssignCustomerInfo(Customer customer)
        {
            customer.CustomerFirstName = txtCustomerFirstName.Text;
            customer.CustomerLastName = txtCustomerLastName.Text;
            customer.CustomerEmail = txtEmail.Text;
            customer.CustomerPhoneNumber = txtPhoneNumber.Text;
            customer.CustomerAddress = txtAddress.Text;
            customer.CustomerStatus = txtStatus.Text;
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
            if (string.IsNullOrWhiteSpace(txtStatus.Text))
            {
                MessageBox.Show("Status cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
