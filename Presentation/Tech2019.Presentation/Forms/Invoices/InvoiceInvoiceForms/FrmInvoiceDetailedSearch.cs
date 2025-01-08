using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Tech2019.BusinessLayer.AbstractServices;
using Tech2019.DTOLayer.InvoiceDetailDTOs;

namespace Tech2019.Presentation.Forms.Invoices.InvoiceInvoiceForms
{
    public partial class FrmInvoiceDetailedSearch : Form
    {
        private readonly IInvoiceDetailService _invoiceDetailService;
        public FrmInvoiceDetailedSearch(IInvoiceDetailService invoiceDetailService)
        {
            _invoiceDetailService = invoiceDetailService;
            InitializeComponent();
        }

        private void FrmInvoiceDetailedSearch_Load(object sender, EventArgs e)
        {
            FillLookUpEditSerialChars();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<ResultInvoiceDetailDTO> invoiceDetailList = null;

            if (!string.IsNullOrEmpty(txtInvoiceId.Text))
            {
                invoiceDetailList = _invoiceDetailService.GetInvoiceDetailListByInvoiceId(int.Parse(txtInvoiceId.Text));

                if (invoiceDetailList != null && invoiceDetailList.Any())
                {
                    var firstInvoice = invoiceDetailList.First();
                    lueInvoiceSerial.EditValue = firstInvoice.InvoiceNumber.Substring(0, 1);
                    txtInvoiceSequence.Text = firstInvoice.InvoiceNumber.Substring(1);
                }
                else
                {
                    ClearInvoiceDetailInfo();
                    MessageBox.Show("No data found for the provided Invoice ID.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (string.IsNullOrEmpty(txtInvoiceId.Text) &&
                     !string.IsNullOrEmpty(txtInvoiceSequence.Text) &&
                     lueInvoiceSerial.EditValue != null)
            {
                invoiceDetailList = _invoiceDetailService.GetInvoiceDetailListByInvoiceSerialAndSequence(
                    lueInvoiceSerial.EditValue.ToString(),
                    txtInvoiceSequence.Text
                );

                if (invoiceDetailList != null && invoiceDetailList.Any())
                {
                    var firstInvoice = invoiceDetailList.First();
                    txtInvoiceId.Text = firstInvoice.InvoiceId.ToString();
                }
                else
                {
                    ClearInvoiceDetailInfo();
                    MessageBox.Show("No data found for the provided Serial and Sequence.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                ClearInvoiceDetailInfo();
                MessageBox.Show("Please provide either an Invoice ID or Serial and Sequence to search.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            grcInvoiceDetailList.DataSource = invoiceDetailList;
        }


        private void FillLookUpEditSerialChars()
        {
            var charList = Enumerable.Range('A', 26).Select(c => new
            {
                SerialChar = ((char)c).ToString()
            }).ToList();

            lueInvoiceSerial.Properties.ValueMember = "SerialChar";
            lueInvoiceSerial.Properties.DisplayMember = "SerialChar";
            lueInvoiceSerial.Properties.DataSource = charList;
            lueInvoiceSerial.Properties.NullText = "Please Pick a Char";
        }

        private bool ValidateInvoiceDetailInfo()
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

            if (!int.TryParse(txtInvoiceId.Text, out _))
            {
                MessageBox.Show("Invoice ID must be a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void ClearInvoiceDetailInfo()
        {
            txtInvoiceId.Text = string.Empty;
            txtInvoiceSequence.Text = string.Empty;
            lueInvoiceSerial.EditValue = null;
        }
    }
}
