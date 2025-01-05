using System.Collections.Generic;
using System.Linq;
using Tech2019.DataAccessLayer.AbstractDAL;
using Tech2019.DataAccessLayer.Context;
using Tech2019.DTOLayer.SaleDTOs;
using Tech2019.EntityLayer.Concrete;

namespace Tech2019.DataAccessLayer.EFConcreteDAL
{
    public class EFSaleDal : EFGenericDal<Sale>, ISaleDal
    {
        TechDBContext _context;
        public EFSaleDal(TechDBContext context) : base(context)
        {
            _context = context;
        }

        public List<ResultSaleDTO> TGetSales()
        {
            return _context.Sales
                .Join(_context.Products,
                      sale => sale.Product,
                      product => product.ProductId,
                      (sale, product) => new { sale, product })
                .Join(_context.Customers,
                      sp => sp.sale.Customer,
                      customer => customer.CustomerId,
                      (sp, customer) => new { sp.sale, sp.product, customer })
                .Join(_context.Employees,
                      spc => spc.sale.Employee,
                      employee => employee.EmployeeId,
                      (spc, employee) => new ResultSaleDTO
                      {
                          SaleId = spc.sale.SaleId,
                          ProductId = spc.product.ProductId,
                          ProductName = spc.product.ProductName,
                          CustomerId = spc.customer.CustomerId,
                          CustomerFullName = spc.customer.CustomerFirstName + " " + spc.customer.CustomerLastName,
                          EmployeeId = employee.EmployeeId,
                          EmployeeFullName = employee.EmployeeFirstName + " " + employee.EmployeeLastName,
                          SaleDate = spc.sale.SaleDate,
                          SaleQuantity = spc.sale.SaleQuantity,
                          SaleTotalPrice = spc.sale.SaleTotalPrice,
                          ProductSerialNumber = spc.sale.ProductSerialNumber
                      })
                .ToList();
        }
    }
}