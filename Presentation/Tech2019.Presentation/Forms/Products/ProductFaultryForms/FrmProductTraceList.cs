using System;
using System.Windows.Forms;
using Tech2019.BusinessLayer.AbstractServices;

namespace Tech2019.Presentation.Forms.Products.ProductFaultryForms
{
    public partial class FrmProductTraceList : Form
    {
        private readonly IProductTraceService _productTraceService;
        public FrmProductTraceList(IProductTraceService productTraceService)
        {
            _productTraceService = productTraceService;
            InitializeComponent();
        }

        private void FrmProductTraceList_Load(object sender, EventArgs e)
        {
            ProductTraceList();
            gvwProductTrace.OptionsBehavior.Editable = false;
        }

        #region Extracted Methods

        private void ProductTraceList()
        {
            var productTraceList = _productTraceService.GetProductTraceList();

            grcProductTraceList.DataSource = productTraceList;
        }

        #endregion
    }
}
