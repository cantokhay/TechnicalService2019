using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Tech2019.DataAccessLayer.Context;
using Tech2019.EntityLayer.Concrete;

namespace Tech2019.Presentation.Forms.Customers.CustomerCustomerForms
{
    public partial class FrmNewCustomer : Form
    {
        public FrmNewCustomer()
        {
            InitializeComponent();
            FillLookUpEditCitiesAndDistricts();
        }

        private void btnNewQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNewSave_Click(object sender, EventArgs e)
        {
            TechDBContext db = new TechDBContext();
            Customer customer = new Customer();
            AssignCustomerInfo(customer);
            db.Customers.Add(customer);
            db.SaveChanges();
            MessageBox.Show("Customer added successfully");
            this.Close();
        }

        #region Extracted Methods

        private void FillLookUpEditCitiesAndDistricts()
        {
            TechDBContext db = new TechDBContext();
            lueCustomerCity.Properties.DataSource = db.Customers.Select(c => c.CustomerCity).Distinct().ToList();
            lueCustomerDistrict.Properties.DataSource = db.Customers.Select(c => c.CustomerDistrict).Distinct().ToList();
        }

        private void AssignCustomerInfo(Customer customer)
        {
            customer.CustomerFirstName = txtCustomerFirstName.Text;
            customer.CustomerLastName = txtCustomerLastName.Text;
            customer.CustomerEmail = txtCustomerEmail.Text;
            customer.CustomerPhoneNumber = txtCustomerPhone.Text;
            customer.CustomerAddress = txtCustomerAddress.Text;
            customer.CustomerStatus = txtCustomerStatus.Text;
            customer.CustomerTaxNumber = txtCustomerTaxNumber.Text;
            customer.CustomerTaxOffice = txtCustomerTaxOffice.Text;
            customer.CustomerBank = txtCustomerBank.Text;
            customer.CustomerCity = lueCustomerCity.EditValue.ToString();
            customer.CustomerDistrict = lueCustomerDistrict.EditValue.ToString();
        }

        #endregion

        private void FrmNewCustomer_Load(object sender, EventArgs e)
        {

        }
    }
}
