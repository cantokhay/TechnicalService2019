using System;
using System.Windows.Forms;
using Tech2019.BusinessLayer.AbstractServices;

namespace Tech2019.Presentation.Forms.Customers.CustomerSaleForms
{
    public partial class FrmSaleList : Form
    {
        private readonly ISaleService _saleService;
        public FrmSaleList(ISaleService saleService)
        {
            _saleService = saleService;
            InitializeComponent();
        }

        private void FrmSaleList_Load(object sender, EventArgs e)
        {
            LoadSaleList();
            gvwSales.OptionsBehavior.Editable = false;
        }

        #region Extracted Methods

        private void LoadSaleList()
        {
            grcSaleList.DataSource = _saleService.GetSales();
        }

        #endregion
    }
}
