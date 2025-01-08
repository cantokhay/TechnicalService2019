using System;
using System.Linq;
using System.Windows.Forms;
using Tech2019.BusinessLayer.AbstractServices;
using Tech2019.EntityLayer.Concrete;

namespace Tech2019.Presentation.Forms.Invoices.InvoiceInvoiceForms
{
    public partial class FrmInvoiceList : Form
    {
        private readonly IInvoiceService _invoiceService;
        private readonly IEmployeeService _employeeService;
        private readonly ICustomerService _customerService;

        public FrmInvoiceList(IInvoiceService invoiceService, IEmployeeService employeeService, ICustomerService customerService)
        {
            _invoiceService = invoiceService;
            _employeeService = employeeService;
            _customerService = customerService;
            InitializeComponent();
        }

        private void FrmInvoiceList_Load(object sender, EventArgs e)
        {
            LoadInvoiceList();
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
            _invoiceService.Create(invoice);
            MessageBox.Show("Invoice Added Successfully", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadInvoiceList();
            ClearInvoiceInfo();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!ValidateInvoiceId())
                return;

            int id = int.Parse(txtInvoiceId.Text);
            var invoice = _invoiceService.GetById(id);
            _invoiceService.Delete(invoice);
            MessageBox.Show("Invoice Deleted", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            LoadInvoiceList();
            ClearInvoiceInfo();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!ValidateInvoiceId())
                return;

            if (!ValidateInvoiceInfo())
                return;

            int id = int.Parse(txtInvoiceId.Text);
            var invoice = _invoiceService.GetById(id);
            AssignInvoiceInfo(invoice);
            _invoiceService.Update(invoice);
            MessageBox.Show("Invoice Updated", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            LoadInvoiceList();
            ClearInvoiceInfo();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadInvoiceList();
            ClearInvoiceInfo();
        }

        private void gvwInvoices_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtInvoiceId.Text = gvwInvoices.GetFocusedRowCellValue("InvoiceId")?.ToString();
            lueInvoiceSerial.EditValue = gvwInvoices.GetFocusedRowCellValue("InvoiceSerialCharacter")?.ToString();
            txtInvoiceSequence.Text = gvwInvoices.GetFocusedRowCellValue("InvoiceSequenceNumber")?.ToString();
            txtInvoiceDate.Text = gvwInvoices.GetFocusedRowCellValue("InvoiceDate")?.ToString();
            txtInvoiceHour.Text = gvwInvoices.GetFocusedRowCellValue("InvoiceHour")?.ToString();
            txtInvoiceTaxOffice.Text = gvwInvoices.GetFocusedRowCellValue("InvoiceTaxOffice")?.ToString();
            lueInvoiceCustomer.EditValue = gvwInvoices.GetFocusedRowCellValue("CustomerId");
            lueInvoiceEmployee.EditValue = gvwInvoices.GetFocusedRowCellValue("EmployeeId");
        }

        #region Extracted Methods

        private void FillLookUpEditSerialCharsEmployeesAndCustomers()
        {
            var customersList = _customerService.GetCustomersToInvoice();
            lueInvoiceCustomer.Properties.DataSource = customersList;
            lueInvoiceCustomer.Properties.DisplayMember = "CustomerFullName";
            lueInvoiceCustomer.Properties.ValueMember = "CustomerId";
            lueInvoiceCustomer.Properties.NullText = "Please pick a customer";

            var employeesList = _employeeService.GetEmployeesToInvoice();
            lueInvoiceEmployee.Properties.DataSource = employeesList;
            lueInvoiceEmployee.Properties.DisplayMember = "EmployeeFullName";
            lueInvoiceEmployee.Properties.ValueMember = "EmployeeId";
            lueInvoiceEmployee.Properties.NullText = "Please pick an employee";

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
            lueInvoiceSerial.EditValue = null;
            txtInvoiceDate.Text = string.Empty;
            txtInvoiceHour.Text = string.Empty;
            txtInvoiceTaxOffice.Text = string.Empty;
            lueInvoiceCustomer.EditValue = null;
            lueInvoiceEmployee.EditValue = null;
        }

        private void LoadInvoiceList()
        {
            var invoiceList = _invoiceService.GetInvoiceList();

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
