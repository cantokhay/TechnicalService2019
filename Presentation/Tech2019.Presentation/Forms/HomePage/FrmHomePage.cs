using System.Windows.Forms;
using Tech2019.BusinessLayer.AbstractServices;

namespace Tech2019.Presentation.Forms.HomePage
{
    public partial class FrmHomePage : Form
    {
        private readonly IProductService _productService;
        private readonly ICustomerService _customerService;
        public FrmHomePage(IProductService productService, ICustomerService customerService)
        {
            _productService = productService;
            _customerService = customerService;
            InitializeComponent();
        }

        private void FrmHomePage_Load(object sender, System.EventArgs e)
        {
            grcCriticalStockLevel.DataSource = _productService.GetProductsOnCriticalStockLevel();
            grcPhoneBook.DataSource = _customerService.GetCustomersToHomePage();
            grcCategoryProduct.DataSource = _productService.GetProductCountByCategoryName();
        }
    }
}
