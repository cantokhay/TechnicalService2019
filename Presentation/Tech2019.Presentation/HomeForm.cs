using System.Windows.Forms;
using Tech2019.BusinessLayer.AbstractServices;

namespace Tech2019.Presentation
{
    public partial class HomeForm : Form
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService; 
        private readonly IDepartmentService _departmentService;
        private readonly IEmployeeService _employeeService;
        private readonly ICustomerService _customerService;

        public HomeForm(IProductService productService, ICategoryService categoryService, IDepartmentService departmentService, IEmployeeService employeeService, ICustomerService customerService)
        {
            InitializeComponent();
            _productService = productService;
            _categoryService = categoryService;
            _departmentService = departmentService;
            _employeeService = employeeService;
            _customerService = customerService;
        }

        private void btnProductListForm_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Products.ProductProductForms.FrmProductList frmProductList = new Forms.Products.ProductProductForms.FrmProductList(_productService, _categoryService);
            frmProductList.MdiParent = this;
            frmProductList.Show();
        }

        private void btnCategoryListForm_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Products.ProductCategoryForms.FrmCategoryList frmCategoryList = new Forms.Products.ProductCategoryForms.FrmCategoryList(_categoryService);
            frmCategoryList.MdiParent = this;
            frmCategoryList.Show();
        }

        private void btnNewProduct_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Products.ProductProductForms.FrmNewProduct frmNewProduct = new Forms.Products.ProductProductForms.FrmNewProduct(_productService, _categoryService);
            frmNewProduct.Show();
        }

        private void btnProductStats_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Products.ProductStatisticForms.FrmProductStats frmProductStats = new Forms.Products.ProductStatisticForms.FrmProductStats(_productService, _categoryService);
            frmProductStats.MdiParent = this;
            frmProductStats.Show();
        }

        private void btnBrandStats_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Products.ProductStatisticForms.FrmBrandStats frmBrandStats = new Forms.Products.ProductStatisticForms.FrmBrandStats(_productService);
            frmBrandStats.MdiParent = this;
            frmBrandStats.Show();
        }

        private void btnCustomerList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Customers.CustomerCustomerForms.FrmCustomerList frmCustomerList = new Forms.Customers.CustomerCustomerForms.FrmCustomerList(_customerService);
            frmCustomerList.MdiParent = this;
            frmCustomerList.Show();
        }

        private void btnNewCustomer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Customers.CustomerCustomerForms.FrmNewCustomer frmNewCustomer = new Forms.Customers.CustomerCustomerForms.FrmNewCustomer(_customerService);
            frmNewCustomer.Show();
        }

        private void btnCustomerCityStats_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Customers.CustomerCustomerForms.FrmCustomerCityStats frmCustomerCityStats = new Forms.Customers.CustomerCustomerForms.FrmCustomerCityStats(_customerService);
            frmCustomerCityStats.MdiParent = this;
            frmCustomerCityStats.Show();
        }

        private void btnDepartmentList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Employees.DepartmentForms.FrmDepartmentList frmDepartmentList = new Forms.Employees.DepartmentForms.FrmDepartmentList(_departmentService, _employeeService);
            frmDepartmentList.MdiParent = this;
            frmDepartmentList.Show();
        }

        private void btnNewDepartment_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Employees.DepartmentForms.FrmNewDepartment frmNewDepartment = new Forms.Employees.DepartmentForms.FrmNewDepartment(_departmentService);
            frmNewDepartment.Show();
        }

        private void btnNewCategory_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Products.ProductCategoryForms.FrmNewCategory frmNewCategory = new Forms.Products.ProductCategoryForms.FrmNewCategory(_categoryService);
            frmNewCategory.Show();
        }

        private void btnEmployeeList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Employees.EmployeeForms.FrmEmployeeList frmEmployeeList = new Forms.Employees.EmployeeForms.FrmEmployeeList(_employeeService, _departmentService);
            frmEmployeeList.MdiParent = this;
            frmEmployeeList.Show();
        }

        private void btnNewEmployee_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Employees.EmployeeForms.FrmNewEmployee frmNewEmployee = new Forms.Employees.EmployeeForms.FrmNewEmployee(_employeeService, _departmentService);
            frmNewEmployee.Show();
        }

        private void btnCalculator_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("calc.exe");
        }

        private void btnCurrency_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Tools.FrmCurrency frmCurrency = new Forms.Tools.FrmCurrency();
            frmCurrency.MdiParent = this;
            frmCurrency.Show();
        }

        private void btnWord_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("winword");
        }

        private void btnExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("excel");
        }

        private void btnYoutube_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Tools.FrmYoutube frmYoutube = new Forms.Tools.FrmYoutube();
            frmYoutube.MdiParent = this;
            frmYoutube.Show();
        }

        private void btnNoteList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Tools.FrmNoteList frmNoteList = new Forms.Tools.FrmNoteList();
            frmNoteList.MdiParent = this;
            frmNoteList.Show();
        }

        private void btnFaultyProductList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Products.ProductFaultryForms.FrmActionsList frmActionsList = new Forms.Products.ProductFaultryForms.FrmActionsList();
            frmActionsList.MdiParent = this;
            frmActionsList.Show();
        }

        private void btnNewSale_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Customers.CustomerSaleForms.FrmNewSale frmNewSale = new Forms.Customers.CustomerSaleForms.FrmNewSale();
            frmNewSale.Show();
        }

        private void btnSaleList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Customers.CustomerSaleForms.FrmSaleList frmSaleList = new Forms.Customers.CustomerSaleForms.FrmSaleList();
            frmSaleList.MdiParent = this;
            frmSaleList.Show();
        }

        private void btnCustomerMovements_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Customers.CustomerSaleForms.FrmSaleList frmSaleList = new Forms.Customers.CustomerSaleForms.FrmSaleList();
            frmSaleList.MdiParent = this;
            frmSaleList.Show();
        }

        private void btnNewFaultyProduct_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Products.ProductFaultryForms.FrmNewAction frmNewAction = new Forms.Products.ProductFaultryForms.FrmNewAction();
            frmNewAction.Show();
        }

        private void btnNewProductTrace_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Products.ProductFaultryForms.FrmNewProductTrace frmNewProductTrace = new Forms.Products.ProductFaultryForms.FrmNewProductTrace();
            frmNewProductTrace.Show();
        }

        private void btnProductTraceList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Products.ProductFaultryForms.FrmProductTraceList frmProductTraceList = new Forms.Products.ProductFaultryForms.FrmProductTraceList();
            frmProductTraceList.MdiParent = this;
            frmProductTraceList.Show();
        }

        private void btnInvoiceList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Invoices.InvoiceInvoiceForms.FrmInvoiceList frmInvoiceList = new Forms.Invoices.InvoiceInvoiceForms.FrmInvoiceList();
            frmInvoiceList.MdiParent = this;
            frmInvoiceList.Show();
        }
    }
}
