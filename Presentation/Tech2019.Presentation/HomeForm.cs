using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Tech2019.BusinessLayer.AbstractServices;

namespace Tech2019.Presentation
{
    public partial class HomeForm : Form
    {
        private readonly IServiceProvider _serviceProvider;

        public HomeForm(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        /// Generic method for opening MDI forms; if the form is already open, it does not reopen it but brings it to the front.
        /// </summary>
        private void OpenMDIForms<T>(params object[] args) where T : Form
        {
            var existingForm = Application.OpenForms.OfType<T>().FirstOrDefault();

            if (existingForm != null && !existingForm.IsDisposed)
            {
                existingForm.BringToFront();
                return;
            }

            var form = (T)Activator.CreateInstance(typeof(T), args);
            form.MdiParent = this;
            form.Show();
        }

        /// <summary>
        /// Generic method for opening Non-MDI forms in a new window.
        /// </summary>
        private void OpenNonMDIForms<T>(params object[] args) where T : Form
        {
            var existingForm = Application.OpenForms.OfType<T>().FirstOrDefault();

            if (existingForm != null && !existingForm.IsDisposed)
            {
                existingForm.BringToFront();
                return;
            }

            var form = (T)Activator.CreateInstance(typeof(T), args);
            form.Show();
        }

        #region MDI Forms

        private void btnProductListForm_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenMDIForms<Forms.Products.ProductProductForms.FrmProductList>(
                _serviceProvider.GetService(typeof(IProductService)),
                _serviceProvider.GetService(typeof(ICategoryService))
            );
        }

        private void btnCategoryListForm_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenMDIForms<Forms.Products.ProductCategoryForms.FrmCategoryList>(
                _serviceProvider.GetService(typeof(ICategoryService))
            );
        }

        private void btnProductStats_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenMDIForms<Forms.Products.ProductStatisticForms.FrmProductStats>(
                _serviceProvider.GetService(typeof(IProductService)),
                _serviceProvider.GetService(typeof(ICategoryService)),
                _serviceProvider.GetService(typeof(IActionService))
            );
        }

        private void btnBrandStats_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenMDIForms<Forms.Products.ProductStatisticForms.FrmBrandStats>(
                _serviceProvider.GetService(typeof(IProductService))
            );
        }

        private void btnCustomerList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenMDIForms<Forms.Customers.CustomerCustomerForms.FrmCustomerList>(
                _serviceProvider.GetService(typeof(ICustomerService))
            );
        }

        private void btnCustomerCityStats_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenMDIForms<Forms.Customers.CustomerCustomerForms.FrmCustomerCityStats>(
                _serviceProvider.GetService(typeof(ICustomerService))
            );
        }

        private void btnDepartmentList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenMDIForms<Forms.Employees.DepartmentForms.FrmDepartmentList>(
                _serviceProvider.GetService(typeof(IDepartmentService)),
                _serviceProvider.GetService(typeof(IEmployeeService))
            );
        }

        private void btnEmployeeList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenMDIForms<Forms.Employees.EmployeeForms.FrmEmployeeList>(
                _serviceProvider.GetService(typeof(IEmployeeService)),
                _serviceProvider.GetService(typeof(IDepartmentService))
            );
        }

        private void btnCurrency_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenMDIForms<Forms.Tools.FrmCurrency>();
        }

        private void btnCalculator_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Process.Start("calc.exe");
        }

        private void btnWord_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Process.Start("winword");
        }

        private void btnExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Process.Start("excel");
        }

        private void btnYoutube_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenMDIForms<Forms.Tools.FrmYoutube>();
        }

        private void btnNoteList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenMDIForms<Forms.Tools.FrmNoteList>(
                _serviceProvider.GetService(typeof(INoteService))
            );
        }

        private void btnFaultyProductList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenMDIForms<Forms.Products.ProductFaultryForms.FrmActionsList>(
                _serviceProvider.GetService(typeof(IActionService))
            );
        }

        private void btnSaleList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenMDIForms<Forms.Customers.CustomerSaleForms.FrmSaleList>(
                _serviceProvider.GetService(typeof(ISaleService))
            );
        }

        private void btnCustomerMovements_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenMDIForms<Forms.Customers.CustomerSaleForms.FrmSaleList>(
                _serviceProvider.GetService(typeof(ISaleService))
            );
        }

        private void btnProductTraceList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenMDIForms<Forms.Products.ProductFaultryForms.FrmProductTraceList>(
                _serviceProvider.GetService(typeof(IProductTraceService))
            );
        }

        private void btnInvoiceList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenMDIForms<Forms.Invoices.InvoiceInvoiceForms.FrmInvoiceList>(
                _serviceProvider.GetService(typeof(IInvoiceService)),
                _serviceProvider.GetService(typeof(IEmployeeService)),
                _serviceProvider.GetService(typeof(ICustomerService))
            );
        }

        private void btnAddProductToInvoice_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenMDIForms<Forms.Invoices.InvoiceInvoiceForms.FrmInvoiceProduct>(
                _serviceProvider.GetService(typeof(IInvoiceService)),
                _serviceProvider.GetService(typeof(IInvoiceDetailService))
            );
        }

        private void btnInvoiceDetailedSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenMDIForms<Forms.Invoices.InvoiceInvoiceForms.FrmInvoiceDetailedSearch>(
                _serviceProvider.GetService(typeof(IInvoiceDetailService))
            );
        }

        private void btnGauges_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenMDIForms<Forms.Tools.FrmGauges>();
        }

        private void btnMaps_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenMDIForms<Forms.Tools.FrmMaps>();
        }

        private void btnHomePage_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenMDIForms<Forms.HomePage.FrmHomePage>(
                _serviceProvider.GetService(typeof(IProductService)),
                _serviceProvider.GetService(typeof(ICustomerService)),
                _serviceProvider.GetService(typeof(INoteService)),
                _serviceProvider.GetService(typeof(IMessageService))
            );
        }

        private void HomeForm_Load(object sender, EventArgs e)
        {
            btnHomePage_ItemClick(sender, null);
        }

        #endregion

        #region Non MDI Forms 

        private void btnReports_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenNonMDIForms<Forms.Reports.FrmReports>();
        }

        private void btnNewFaultyProduct_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenNonMDIForms<Forms.Products.ProductFaultryForms.FrmNewAction>(
                _serviceProvider.GetService(typeof(IActionService)),
                _serviceProvider.GetService(typeof(ICustomerService)),
                _serviceProvider.GetService(typeof(IEmployeeService))
            );
        }

        private void btnNewSale_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenNonMDIForms<Forms.Customers.CustomerSaleForms.FrmNewSale>(
                _serviceProvider.GetService(typeof(ISaleService)),
                _serviceProvider.GetService(typeof(ICustomerService)),
                _serviceProvider.GetService(typeof(IEmployeeService)),
                _serviceProvider.GetService(typeof(IProductService))
            );
        }

        private void btnNewEmployee_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenNonMDIForms<Forms.Employees.EmployeeForms.FrmNewEmployee>(
                _serviceProvider.GetService(typeof(IEmployeeService)),
                _serviceProvider.GetService(typeof(IDepartmentService))
            );
        }

        private void btnNewDepartment_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenNonMDIForms<Forms.Employees.DepartmentForms.FrmNewDepartment>(
                _serviceProvider.GetService(typeof(IDepartmentService))
            );
        }

        private void btnNewCustomer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenNonMDIForms<Forms.Customers.CustomerCustomerForms.FrmNewCustomer>(
                _serviceProvider.GetService(typeof(ICustomerService))
            );
        }

        private void btnNewProduct_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenNonMDIForms<Forms.Products.ProductProductForms.FrmNewProduct>(
                _serviceProvider.GetService(typeof(IProductService)),
                _serviceProvider.GetService(typeof(ICategoryService))
            );
        }

        private void btnNewCategory_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenNonMDIForms<Forms.Products.ProductCategoryForms.FrmNewCategory>(
                _serviceProvider.GetService(typeof(ICategoryService))
            );
        }

        private void btnNewProductTrace_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenNonMDIForms<Forms.Products.ProductFaultryForms.FrmNewProductTrace>(
                _serviceProvider.GetService(typeof(IProductTraceService)),
                _serviceProvider.GetService(typeof(IActionService))
            );
        }

        #endregion
    }
}
