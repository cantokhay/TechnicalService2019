﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;
using Tech2019.BusinessLayer.AbstractServices;
using Tech2019.BusinessLayer.ConcreteManagers;
using Tech2019.DataAccessLayer.AbstractDAL;
using Tech2019.DataAccessLayer.Context;
using Tech2019.DataAccessLayer.EFConcreteDAL;

namespace Tech2019.Presentation
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var serviceProvider = ConfigureServices();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new HomeForm(serviceProvider));
        }

        private static Microsoft.Extensions.DependencyInjection.ServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddScoped<TechDBContext>();

            services.AddScoped<IProductDal, EFProductDal>();
            services.AddScoped<ICategoryDal, EFCategoryDal>();
            services.AddScoped<IDepartmentDal, EFDepartmentDal>();
            services.AddScoped<IEmployeeDal, EFEmployeeDal>();
            services.AddScoped<ICustomerDal, EFCustomerDal>();
            services.AddScoped<INoteDal, EFNoteDal>();
            services.AddScoped<ISaleDal, EFSaleDal>();
            services.AddScoped<IActionDal, EFActionDal>();
            services.AddScoped<IProductTraceDal, EFProductTraceDal>();
            services.AddScoped<IInvoiceDal, EFInvoiceDal>();
            services.AddScoped<IInvoiceDetailDal, EFInvoiceDetailDal>();
            services.AddScoped<IAboutDal, EFAboutDal>();
            services.AddScoped<IMessageDal, EFMessageDal>();
            services.AddScoped<IAdminDal, EFAdminDal>();
            services.AddScoped<IExpenseDal, EFExpenseDal>();
            services.AddScoped<IFaultDetailDal, EFFaultDetailDal>();

            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<IDepartmentService, DepartmentManager>();
            services.AddScoped<IEmployeeService, EmployeeManager>();
            services.AddScoped<ICustomerService, CustomerManager>();
            services.AddScoped<INoteService, NoteManager>();
            services.AddScoped<ISaleService, SaleManager>();
            services.AddScoped<IActionService, ActionManager>();
            services.AddScoped<IProductTraceService, ProductTraceManager>();
            services.AddScoped<IInvoiceService, InvoiceManager>();
            services.AddScoped<IInvoiceDetailService, InvoiceDetailManager>();
            services.AddScoped<IAboutService, AboutManager>();
            services.AddScoped<IMessageService, MessageManager>();
            services.AddScoped<IAdminService, AdminManager>();
            services.AddScoped<IExpenseService, ExpenseManager>();
            services.AddScoped<IFaultDetailService, FaultDetailManager>();

            return services.BuildServiceProvider();
        }
    }
}
