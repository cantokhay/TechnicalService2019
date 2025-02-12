using System;
using System.Windows.Forms;
using Tech2019.BusinessLayer.AbstractServices;

namespace Tech2019.Presentation.Forms.Products.ProductStatisticForms
{
    public partial class FrmProductStats : Form
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IActionService _actionService;

        public FrmProductStats(IProductService productService, ICategoryService categoryService, IActionService actionService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _actionService = actionService;
            InitializeComponent();
        }

        private void FrmProductStats_Load(object sender, EventArgs e)
        {
            lblTotalProductStat.Text = _productService.GetTotalProductCount().ToString();
            lblTotalCategoriesStat.Text = _categoryService.GetTotalCategoryCount().ToString();
            lblTotalStockStat.Text = _productService.GetTotalProductInStock().ToString();
            lblCritLevelStat.Text = _productService.GetProductsCountOnCriticalStockLevel().ToString();
            //lblTodaySoldProductsStat
            lblMaxStockProductStat.Text = _productService.GetMaxStockedProduct();
            lblMinStockProductStat.Text = _productService.GetMinStockedProduct();
            lblMostProductCategoryStat.Text = _categoryService.GetCategoryWithMostProduct();
            lblMaxPricedProductStat.Text = _productService.GetMostExpensiveProduct();
            lblMinPricedProductStat.Text = _productService.GetCheapestProduct();
            lblTotalBrandsStat.Text = _productService.GetTotalBrandCount().ToString();
            lblMostStockedBrandStat.Text = _productService.GetMostStockedBrand();
            lblFaultyProductsStat.Text = _actionService.GetActionCount().ToString();
            //lblProductsUnderRepairStat
            //lblTodayFaultyProductsStat
            lblTotalApplianceStat.Text = _productService.GetProductCountWithCategoryNameAppliance().ToString();
            lblTotalComputersStat.Text = _productService.GetProductCountWithCategoryNameComputer().ToString();
            lblTotalGamingStat.Text = _productService.GetProductCountWithCategoryNameGaming().ToString();
            //lblProductsAfterRepairStat
            //lblProductsReadyCargoStat
        }
    }
}
