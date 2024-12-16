using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Tech2019.DataAccessLayer.Context;
using Tech2019.EntityLayer.Concrete;

namespace Tech2019.Presentation.Forms.Invoices.InvoiceInvoiceForms
{
    public partial class FrmInvoiceList : Form
    {
        TechDBContext db = new TechDBContext();

        public FrmInvoiceList()
        {
            InitializeComponent();
        }

        private void FrmInvoiceList_Load(object sender, EventArgs e)
        {
            InvoiceList();
            FillLookUpEditSerialCharsEmployeesAndCustomers();
            ClearInvoiceInfo();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Invoice invoice = new Invoice();
            AssignInvoiceInfo(invoice);
            db.Invoices.Add(invoice);
            db.SaveChanges();
            MessageBox.Show("Invoice Added Successfully", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearInvoiceInfo();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtInvoiceId.Text);
            var invoice = db.Invoices.Find(id);

            db.Invoices.Remove(invoice);
            db.SaveChanges();
            MessageBox.Show("Invoice Deleted", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            ClearInvoiceInfo();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtInvoiceId.Text);
            var invoice = db.Invoices.Find(id);

            if (invoice != null)
            {
                AssignInvoiceInfo(invoice);
                db.SaveChanges();
                MessageBox.Show("Invoice Updated", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Invoice Not Found", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ClearInvoiceInfo();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            InvoiceList();
            ClearInvoiceInfo();
        }

        private void gvwInvoices_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtInvoiceId.Text = gvwInvoices.GetFocusedRowCellValue("InvoiceId").ToString();
            lueInvoiceSerial.EditValue = gvwInvoices.GetFocusedRowCellValue("InvoiceSerialCharacter").ToString();
            txtInvoiceSequence.Text = gvwInvoices.GetFocusedRowCellValue("InvoiceSequenceNumber").ToString();
            txtInvoiceDate.Text = gvwInvoices.GetFocusedRowCellValue("InvoiceDate").ToString();
            txtInvoiceHour.Text = gvwInvoices.GetFocusedRowCellValue("InvoiceHour").ToString();
            txtInvoiceTaxOffice.Text = gvwInvoices.GetFocusedRowCellValue("InvoiceTaxOffice").ToString();
            var customerId = gvwInvoices.GetFocusedRowCellValue("Customer");
            lueInvoiceCustomer.EditValue = Convert.ToInt32(customerId);
            var employeeId = gvwInvoices.GetFocusedRowCellValue("Employee");
            lueInvoiceEmployee.EditValue = Convert.ToSByte(employeeId);
        }

        #region Extracted Methods

        private void FillLookUpEditSerialCharsEmployeesAndCustomers()
        {
            var customersList = db.Customers.Select(x => new
            {
                x.CustomerId,
                Customer = x.CustomerFirstName + " " + x.CustomerLastName,
            }).ToList();
            lueInvoiceCustomer.Properties.DataSource = customersList;

            var employeesList = db.Employees.Select(x => new
            {
                x.EmployeeId,
                Employee = x.EmployeeFirstName + " " + x.EmployeeLastName
            }).ToList();
            lueInvoiceEmployee.Properties.DataSource = employeesList;

            var charList = Enumerable.Range('A', 26)
                                  .Select(c => new { SerialChar = c.ToString() });
            lueInvoiceSerial.Properties.DataSource = charList.ToList();
        }

        private void ClearInvoiceInfo()
        {
            txtInvoiceId.Text = string.Empty;
            txtInvoiceSequence.Text = string.Empty;
            txtInvoiceDate.Text = string.Empty;
            txtInvoiceHour.Text = string.Empty;
            txtInvoiceTaxOffice.Text = string.Empty;
            lueInvoiceCustomer.EditValue = null;
            lueInvoiceEmployee.EditValue = null;
            lueInvoiceSerial.EditValue = null;
        }

        private void InvoiceList()
        {
            var invoiceList = from i in db.Invoices
                              select new
                              {
                                  i.InvoiceId,
                                  i.InvoiceSequenceNumber,
                                  i.InvoiceSerialCharacter,
                                  i.InvoiceDate,
                                  i.InvoiceHour,
                                  i.InvoiceTaxOffice,
                                  CustomerId = i.Customer,
                                  CustomerFullName = i.CustomerNavigation.CustomerFirstName + " " + i.CustomerNavigation.CustomerLastName,
                                  EmployeeId = i.Employee,
                                  EmployeeFullName = i.EmployeeNavigation.EmployeeFirstName + " " + i.EmployeeNavigation.EmployeeLastName
                              };
            grcInvoiceList.DataSource = invoiceList.ToList();
        }

        private void AssignInvoiceInfo(Invoice invoice)
        {
            invoice.InvoiceDate = DateTime.Parse(txtInvoiceDate.Text.ToString());
            invoice.InvoiceHour = txtInvoiceHour.Text.ToString();
            invoice.InvoiceSequenceNumber = txtInvoiceSequence.Text.ToString();
            invoice.InvoiceTaxOffice = txtInvoiceTaxOffice.Text;
            invoice.InvoiceSerialCharacter = lueInvoiceSerial.EditValue.ToString();
            invoice.Customer = int.Parse(lueInvoiceCustomer.EditValue.ToString());
            invoice.Employee = short.Parse(lueInvoiceEmployee.EditValue.ToString());
        }

        #endregion

    }
}
