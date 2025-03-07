using System.Diagnostics;
using System.Windows.Forms;
using Tech2019.BusinessLayer.AbstractServices;

namespace Tech2019.Presentation.Forms.Invoices.InvoiceInvoiceForms
{
    public partial class FrmInvoiceDetailPopUp : Form
    {
        private readonly IInvoiceDetailService _invoiceDetailService;
        private readonly IInvoiceService _invoiceService;

        public FrmInvoiceDetailPopUp(IInvoiceDetailService invoiceDetailService, IInvoiceService invoiceService)
        {
            _invoiceDetailService = invoiceDetailService;
            _invoiceService = invoiceService;
            InitializeComponent();
        }

        public string id;

        private void FrmInvoiceDetailPopUp_Load(object sender, System.EventArgs e)
        {
            grcInvoiceDetailList.DataSource = _invoiceDetailService.GetInvoiceDetailListByInvoiceId(int.Parse(id));
            grcInvoiceList.DataSource = _invoiceService.GetInvoiceInfoToInvoiceDetailPoUpById(int.Parse(id));
        }

        private void picPdfButton_Click(object sender, System.EventArgs e)
        {
            string path = "doc1.pdf";
            grcInvoiceDetailList.ExportToPdf(path);
        }

        private void picClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
