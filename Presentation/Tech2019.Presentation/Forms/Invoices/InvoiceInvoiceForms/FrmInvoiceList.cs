using System;
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
            if (!ValidateInvoiceInfo())
                return;

            Invoice invoice = new Invoice();

            if (DateTime.TryParse(txtInvoiceDate.Text, out DateTime invoiceDate) &&
                TimeSpan.TryParse(txtInvoiceHour.Text, out TimeSpan invoiceHour))
            {
                invoice.InvoiceDate = invoiceDate.Date.Add(invoiceHour);
            }
            else
            {
                MessageBox.Show("Invalid date or hour format. Ensure both are correctly filled.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            AssignInvoiceInfo(invoice);
            db.Invoices.Add(invoice);
            db.SaveChanges();

            MessageBox.Show("Invoice Added Successfully", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            InvoiceList();
            ClearInvoiceInfo();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!ValidateInvoiceId())
                return;

            int id = int.Parse(txtInvoiceId.Text);
            var invoice = db.Invoices.Find(id);

            if (invoice != null)
            {
                db.Invoices.Remove(invoice);
                db.SaveChanges();
                MessageBox.Show("Invoice Deleted", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                MessageBox.Show("Invoice Not Found", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            InvoiceList();
            ClearInvoiceInfo();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!ValidateInvoiceId())
                return;

            if (!ValidateInvoiceInfo())
                return;

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

            InvoiceList();
            ClearInvoiceInfo();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            InvoiceList();
            ClearInvoiceInfo();
        }

        private void gvwInvoices_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtInvoiceId.Text = gvwInvoices.GetFocusedRowCellValue("InvoiceId")?.ToString();
            lueInvoiceSerial.EditValue = gvwInvoices.GetFocusedRowCellValue("InvoiceSerialCharacter")?.ToString();
            txtInvoiceSequence.Text = gvwInvoices.GetFocusedRowCellValue("InvoiceSequenceNumber")?.ToString();
            txtInvoiceDate.Text = gvwInvoices.GetFocusedRowCellValue("Date")?.ToString();
            txtInvoiceHour.Text = gvwInvoices.GetFocusedRowCellValue("Hour")?.ToString();
            txtInvoiceTaxOffice.Text = gvwInvoices.GetFocusedRowCellValue("InvoiceTaxOffice")?.ToString();
            lueInvoiceCustomer.EditValue = gvwInvoices.GetFocusedRowCellValue("CustomerId");
            lueInvoiceEmployee.EditValue = gvwInvoices.GetFocusedRowCellValue("EmployeeId");
        }

        private void txtInvoiceDate_LostFocus(object sender, EventArgs e)
        {
            if (!DateTime.TryParse(txtInvoiceDate.Text, out DateTime result))
            {
                MessageBox.Show("Invalid date format. Please use dd-MM-yyyy.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtInvoiceDate.Text = string.Empty;
            }
        }

        private void txtInvoiceHour_LostFocus(object sender, EventArgs e)
        {
            if (!TimeSpan.TryParse(txtInvoiceHour.Text, out TimeSpan result))
            {
                MessageBox.Show("Invalid hour format. Please use HH:mm.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtInvoiceHour.Text = string.Empty;
            }
            else
            {
                txtInvoiceHour.Text = result.ToString(@"hh\:mm");
            }
        }

        #region Extracted Methods

        private void FillLookUpEditSerialCharsEmployeesAndCustomers()
        {
            var customersList = db.Customers.Select(x => new
            {
                x.CustomerId,
                CustomerFullName = x.CustomerFirstName + " " + x.CustomerLastName,
            }).ToList();

            lueInvoiceCustomer.Properties.ValueMember = "CustomerId";
            lueInvoiceCustomer.Properties.DisplayMember = "CustomerFullName";
            lueInvoiceCustomer.Properties.DataSource = customersList;
            lueInvoiceCustomer.Properties.NullText = "Please Pick a Customer";

            var employeesList = db.Employees.Select(x => new
            {
                x.EmployeeId,
                EmployeeFullName = x.EmployeeFirstName + " " + x.EmployeeLastName
            }).ToList();

            lueInvoiceEmployee.Properties.ValueMember = "EmployeeId";
            lueInvoiceEmployee.Properties.DisplayMember = "EmployeeFullName";
            lueInvoiceEmployee.Properties.DataSource = employeesList;
            lueInvoiceEmployee.Properties.NullText = "Please Pick an Employee";

            var charList = Enumerable.Range('A', 26).Select(c => new
            {
                SerialChar = ((char)c).ToString()
            }).ToList();

            lueInvoiceSerial.Properties.ValueMember = "SerialChar";
            lueInvoiceSerial.Properties.DisplayMember = "SerialChar";
            lueInvoiceSerial.Properties.DataSource = charList;
            lueInvoiceSerial.Properties.NullText = "Please Pick a Char";
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
            var invoiceList = db.Invoices
                .Select(i => new
                {
                    i.InvoiceId,
                    i.InvoiceSequenceNumber,
                    i.InvoiceSerialCharacter,
                    InvoiceDate = i.InvoiceDate,
                    i.InvoiceTaxOffice,
                    CustomerId = i.Customer,
                    CustomerFullName = i.CustomerNavigation.CustomerFirstName + " " + i.CustomerNavigation.CustomerLastName,
                    EmployeeId = i.Employee,
                    EmployeeFullName = i.EmployeeNavigation.EmployeeFirstName + " " + i.EmployeeNavigation.EmployeeLastName
                })
                .ToList()
                .Select(i => new
                {
                    i.InvoiceId,
                    i.InvoiceSequenceNumber,
                    i.InvoiceSerialCharacter,
                    Date = i.InvoiceDate.ToString("dd-MM-yyyy"),
                    Hour = i.InvoiceDate.ToString("HH:mm"),
                    i.InvoiceTaxOffice,
                    i.CustomerId,
                    i.CustomerFullName,
                    i.EmployeeId,
                    i.EmployeeFullName
                }).ToList();

            grcInvoiceList.DataSource = invoiceList;
        }

        private void AssignInvoiceInfo(Invoice invoice)
        {
            if (DateTime.TryParse(txtInvoiceDate.Text, out DateTime invoiceDate) &&
                TimeSpan.TryParse(txtInvoiceHour.Text, out TimeSpan invoiceTime))
            {
                invoice.InvoiceDate = invoiceDate.Date + invoiceTime;
            }
            else
            {
                MessageBox.Show("Please provide a valid date and time.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            invoice.InvoiceSequenceNumber = txtInvoiceSequence.Text;
            invoice.InvoiceTaxOffice = txtInvoiceTaxOffice.Text;
            invoice.InvoiceSerialCharacter = lueInvoiceSerial.EditValue.ToString();
            invoice.Customer = int.Parse(lueInvoiceCustomer.EditValue.ToString());
            invoice.Employee = short.Parse(lueInvoiceEmployee.EditValue.ToString());
        }

        #endregion

        #region Validation Methods

        private bool ValidateInvoiceInfo()
        {
            if (lueInvoiceSerial.EditValue == null)
            {
                MessageBox.Show("Please select a serial character.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtInvoiceSequence.Text))
            {
                MessageBox.Show("Invoice sequence number cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtInvoiceDate.Text) || !DateTime.TryParse(txtInvoiceDate.Text, out _))
            {
                MessageBox.Show("Please provide a valid date in dd-MM-yyyy format.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtInvoiceHour.Text) || !TimeSpan.TryParse(txtInvoiceHour.Text, out _))
            {
                MessageBox.Show("Please provide a valid hour in HH:mm format.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtInvoiceTaxOffice.Text))
            {
                MessageBox.Show("Tax office cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (lueInvoiceCustomer.EditValue == null)
            {
                MessageBox.Show("Please select a customer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (lueInvoiceEmployee.EditValue == null)
            {
                MessageBox.Show("Please select an employee.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private bool ValidateInvoiceId()
        {
            if (string.IsNullOrWhiteSpace(txtInvoiceId.Text))
            {
                MessageBox.Show("Invoice ID cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!int.TryParse(txtInvoiceId.Text, out _))
            {
                MessageBox.Show("Invoice ID must be a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        #endregion
    }
}
