using System;
using System.Windows.Forms;
using Tech2019.BusinessLayer.AbstractServices;

namespace Tech2019.Presentation.Forms.Products.ProductFaultryForms
{
    public partial class FrmActionsList : Form
    {
        private readonly IActionService _actionService;
        public FrmActionsList(IActionService actionService)
        {
            _actionService = actionService;
            InitializeComponent();
        }

        private void FrmActionsList_Load(object sender, EventArgs e)
        {
            LoadActionsList();
            FillChartWithActionData();
            gvwActions.OptionsBehavior.Editable = false;
        }

        #region Extracted Methods

        private void LoadActionsList()
        {
            grcActionsList.DataSource = _actionService.GetActions();
            lblTotalFaultyProductStat.Text = _actionService.GetActionCount().ToString();
            lblFinishedFaultyProductStat.Text = _actionService.GetRepairFinishedActionCount().ToString();
            lblCustomerApprovePendingStat.Text = _actionService.GetActionCountByPendingCustomerApproveActionStatusDetail().ToString();
            lblCancelledFaultryCountStat.Text = _actionService.GetActionCountByCancelledActionStatusDetail().ToString();
            lblMostProductsFaultAsBrandStat.Text = _actionService.GetMostFaultyProductBrand();
            lblSparePartPendingStat.Text = _actionService.GetActionCountByPendingSparePartActionStatusDetail().ToString();

        }

        private void FillChartWithActionData()
        {
            var data = _actionService.GetActionDataToChart();

            chartControl1.Series[0].Points.Clear();
            foreach (var item in data)
            {
                chartControl1.Series[0].Points.AddPoint(item.Brand, item.ActionCount);
            }
        }

        #endregion
    }
}
