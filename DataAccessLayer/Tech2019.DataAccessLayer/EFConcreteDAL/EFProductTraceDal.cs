using System.Collections.Generic;
using System.Linq;
using Tech2019.DataAccessLayer.AbstractDAL;
using Tech2019.DataAccessLayer.Context;
using Tech2019.DTOLayer.CustomerDTO;
using Tech2019.DTOLayer.ProductTraceDTOs;
using Tech2019.EntityLayer.Concrete;

namespace Tech2019.DataAccessLayer.EFConcreteDAL
{
    public class EFProductTraceDal : EFGenericDal<ProductTrace>, IProductTraceDal
    {
        private readonly TechDBContext _context;

        public EFProductTraceDal(TechDBContext context) : base(context)
        {
            _context = context;
        }

        public List<ResultProductTraceDTO> TGetProductTraceList()
        {
            return _context.ProductTraces
                .Where(pt => pt.DataStatus != EntityLayer.Enum.DataStatus.Deleted)
                .Select(pt => new ResultProductTraceDTO
                {
                    ProductTraceId = pt.ProductTraceId,
                    ProductTraceDate = pt.ProductTraceDate,
                    ProductTraceDetail = pt.ProductTraceInformation,
                    SaleDate = _context.Sales
                        .Where(s => s.ProductSerialNumber == pt.ProductSerialNumber)
                        .Select(s => s.SaleDate)
                        .FirstOrDefault(),
                    ProductName = _context.Sales
                        .Where(s => s.ProductSerialNumber == pt.ProductSerialNumber)
                        .Select(s => _context.Products
                            .Where(p => p.ProductId == s.Product)
                            .Select(p => p.ProductName).FirstOrDefault())
                        .FirstOrDefault(),
                    CustomerName = _context.Sales
                        .Where(s => s.ProductSerialNumber == pt.ProductSerialNumber)
                        .Select(s => _context.Customers
                            .Where(c => c.CustomerId == s.Customer)
                            .Select(c => c.CustomerFirstName + " " + c.CustomerLastName).FirstOrDefault())
                        .FirstOrDefault(),
                    EmployeeName = _context.Sales
                        .Where(s => s.ProductSerialNumber == pt.ProductSerialNumber)
                        .Select(s => _context.Employees
                            .Where(e => e.EmployeeId == s.Employee)
                            .Select(e => e.EmployeeFirstName + " " + e.EmployeeLastName).FirstOrDefault())
                        .FirstOrDefault()
                })
                .ToList();
        }
        public ResultCustomerInfoBySerialDTO TGetCustomerInfoBySerial(string serialNumber)
        {
            return _context.Sales
                .Where(s => s.DataStatus != EntityLayer.Enum.DataStatus.Deleted)
                .Where(s => s.ProductSerialNumber == serialNumber)
                .Join(_context.Customers,
                      sale => sale.Customer,
                      customer => customer.CustomerId,
                      (sale, customer) => new ResultCustomerInfoBySerialDTO
                      {
                          CustomerFirstName = customer.CustomerFirstName,
                          CustomerLastName = customer.CustomerLastName,
                          SaleDate = sale.SaleDate
                      })
                .FirstOrDefault();
        }
    }
}