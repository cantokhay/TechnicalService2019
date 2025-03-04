using System;
using System.Windows.Forms;
using Tech2019.BusinessLayer.AbstractServices;
using Tech2019.EntityLayer.Concrete;

namespace Tech2019.Presentation.Forms.Invoices.InvoiceInvoiceForms
{
    public partial class FrmInvoiceProduct : Form
    {
        private readonly IInvoiceService _invoiceService;
        private readonly IInvoiceDetailService _invoiceDetailService;

        public FrmInvoiceProduct(IInvoiceService invoiceService, IInvoiceDetailService invoiceDetailService)
        {
            _invoiceService = invoiceService;
            _invoiceDetailService = invoiceDetailService;
            InitializeComponent();
        }

        private void FrmInvoiceProduct_Load(object sender, EventArgs e)
        {
            LoadInvoiceDetailList();
            FillLookUpEditInvoices();
            ClearInvoiceDetailInfo();
            gvwInvoiceDetails.OptionsBehavior.Editable = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInvoiceDetailInfo())
                return;

            var invoiceDetail = new InvoiceDetail();
            AssignInvoiceDetailInfo(invoiceDetail);
            _invoiceDetailService.Create(invoiceDetail);
            MessageBox.Show("Invoice Detail Saved", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            LoadInvoiceDetailList();
            ClearInvoiceDetailInfo();
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!ValidateInvoiceDetailId())
                return;

            int id = int.Parse(txtInvoiceDetailId.Text);
            var invoiceDetail = _invoiceDetailService.GetById(id);
            _invoiceDetailService.Delete(invoiceDetail);
            MessageBox.Show("Invoice Detail Deleted", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            LoadInvoiceDetailList();
            ClearInvoiceDetailInfo();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!ValidateInvoiceDetailId())
                return;

            if (!ValidateInvoiceDetailInfo())
                return;

            int id = int.Parse(txtInvoiceDetailId.Text);
            var invoiceDetail = _invoiceDetailService.GetById(id);
            AssignInvoiceDetailInfo(invoiceDetail);
            _invoiceDetailService.Update(invoiceDetail);
            MessageBox.Show("Invoice Detail Updated", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            LoadInvoiceDetailList();
            ClearInvoiceDetailInfo();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadInvoiceDetailList();
            ClearInvoiceDetailInfo();
        }

        private void gvwInvoiceDetails_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtInvoiceDetailId.Text = gvwInvoiceDetails.GetFocusedRowCellValue("InvoiceDetailId")?.ToString();
            txtInvoiceDetailProductName.Text = gvwInvoiceDetails.GetFocusedRowCellValue("ProductName")?.ToString();
            txtInvoiceDetailQuantity.Text = gvwInvoiceDetails.GetFocusedRowCellValue("ProductSaleQuantity")?.ToString();
            txtInvoiceDetailPrice.Text = gvwInvoiceDetails.GetFocusedRowCellValue("ProductUnitPrice")?.ToString();
            txtInvoiceDetailTotal.Text = gvwInvoiceDetails.GetFocusedRowCellValue("ProductTotalPrice")?.ToString();
            lueInvoices.EditValue = gvwInvoiceDetails.GetFocusedRowCellValue("InvoiceId");
        }

        #region Extrated Methods

        private void LoadInvoiceDetailList()
        {
            var invoiceDetailList = _invoiceDetailService.GetInvoiceDetailList();
            grcInvoiceDetailList.DataSource = invoiceDetailList;
        }

        private void FillLookUpEditInvoices()
        {
            var invoiceList = _invoiceService.GetInvoiceListToInvoiceDetail();
            lueInvoices.Properties.DataSource = invoiceList;
            lueInvoices.Properties.DisplayMember = "InvoiceNumber";
            lueInvoices.Properties.ValueMember = "InvoiceId";
            lueInvoices.Properties.NullText = "Please pick an invoice";
        }

        private void ClearInvoiceDetailInfo()
        {
            txtInvoiceDetailId.Text = string.Empty;
            txtInvoiceDetailProductName.Text = string.Empty;
            txtInvoiceDetailQuantity.Text = string.Empty;
            txtInvoiceDetailPrice.Text = string.Empty;
            txtInvoiceDetailTotal.Text = string.Empty;
            lueInvoices.EditValue = null;
        }

        private void AssignInvoiceDetailInfo(InvoiceDetail invoiceDetail)
        {
            invoiceDetail.ProductName = txtInvoiceDetailProductName.Text;
            invoiceDetail.ProductSaleQuantity = short.Parse(txtInvoiceDetailQuantity.Text);
            invoiceDetail.ProductUnitPrice = decimal.Parse(txtInvoiceDetailPrice.Text);
            invoiceDetail.ProductTotalPrice = decimal.Parse(txtInvoiceDetailTotal.Text);
            invoiceDetail.Invoice = int.Parse(lueInvoices.EditValue.ToString());
        }

        #region Validation Methods

        private bool ValidateInvoiceDetailInfo()
        {
            if (string.IsNullOrWhiteSpace(txtInvoiceDetailQuantity.Text) || !int.TryParse(txtInvoiceDetailQuantity.Text, out _))
            {
                MessageBox.Show("Product Quantity cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtInvoiceDetailPrice.Text) || !decimal.TryParse(txtInvoiceDetailPrice.Text, out _))
            {
                MessageBox.Show("Product Price cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtInvoiceDetailTotal.Text) || !decimal.TryParse(txtInvoiceDetailTotal.Text, out _))
            {
                MessageBox.Show("Total Price cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtInvoiceDetailProductName.Text))
            {
                MessageBox.Show("Product Name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (lueInvoices.EditValue == null)
            {
                MessageBox.Show("Please select an invoice.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private bool ValidateInvoiceDetailId()
        {
            if (string.IsNullOrWhiteSpace(txtInvoiceDetailId.Text))
            {
                MessageBox.Show("Invoice Detail ID cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!int.TryParse(txtInvoiceDetailId.Text, out _))
            {
                MessageBox.Show("Invoice Detail ID must be a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        #endregion

        #endregion

    }
}

