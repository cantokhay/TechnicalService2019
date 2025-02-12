using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using Tech2019.BusinessLayer.AbstractServices;

namespace Tech2019.Presentation.Forms.Products.ProductStatisticForms
{
    public partial class FrmBrandStats : Form
    {
        private readonly IProductService _productService;
        public FrmBrandStats(IProductService productService)
        {
            _productService = productService;
            InitializeComponent();
        }

        private void FrmBrandStats_Load(object sender, EventArgs e)
        {
            grcBrandsList.DataSource = _productService.GetProductBrandStats();

            lblTotalProductStat.Text = _productService.GetTotalProductCount().ToString();
            lblTotalBrandsStat.Text = _productService.GetTotalBrandCount().ToString();
            lblMostStockedBrandStat.Text = _productService.GetMostStockedBrand();
            lblMostPricedProductBrandStat.Text = _productService.GetMostExpensiveProduct();
            gvwBrands.OptionsBehavior.Editable = false;

            SqlConnection sqlConnection = new SqlConnection(@"Data Source=CAN-TOKHAY-MASA\CANTOKHAY;initial Catalog=Tech2019DB;integrated Security=True;");
            //TODO : populate the charts
        }
    }
}
