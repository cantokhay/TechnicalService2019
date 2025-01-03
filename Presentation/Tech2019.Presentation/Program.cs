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
            var productService = serviceProvider.GetRequiredService<IProductService>();
            var categoryService = serviceProvider.GetRequiredService<ICategoryService>();
            var departmentService = serviceProvider.GetRequiredService<IDepartmentService>();
            var employeeService = serviceProvider.GetRequiredService<IEmployeeService>();
            var customerService = serviceProvider.GetRequiredService<ICustomerService>();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new HomeForm(productService, categoryService, departmentService, employeeService, customerService));
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

            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<IDepartmentService, DepartmentManager>();
            services.AddScoped<IEmployeeService, EmployeeManager>();
            services.AddScoped<ICustomerService, CustomerManager>();

            return services.BuildServiceProvider();
        }
    }
}
