using System.Collections.Generic;
using System.Linq;
using Tech2019.DataAccessLayer.AbstractDAL;
using Tech2019.DataAccessLayer.Context;
using Tech2019.DTOLayer.ActionDTOs;
using Tech2019.DTOLayer.CustomerDTO;

namespace Tech2019.DataAccessLayer.EFConcreteDAL
{
    public class EFActionDal : EFGenericDal<EntityLayer.Concrete.Action>, IActionDal
    {
        private readonly TechDBContext _context;
        public EFActionDal(TechDBContext context) : base(context)
        {
            _context = context;
        }

        public List<ResultActionToChartDTO> TGetActionDataToChart()
        {
            return _context.Actions
                .Where(a => a.DataStatus != EntityLayer.Enum.DataStatus.Deleted)
                .Join(_context.Sales,
                      action => action.ProductSerialNumber,
                      sale => sale.ProductSerialNumber,
                      (action, sale) => new
                      {
                          ProductBrand = sale.ProductNavigation.ProductBrand,
                          ActionId = action.ActionId
                      })
                .GroupBy(x => x.ProductBrand)
                .Select(g => new ResultActionToChartDTO
                {
                    Brand = g.Key,
                    ActionCount = g.Count()
                })
                .ToList();
        }

        public List<ResultActionDTO> TGetActions()
        {
            return _context.Actions
                .Where(a => a.DataStatus != EntityLayer.Enum.DataStatus.Deleted)
                .Select(x => new ResultActionDTO
                {
                    ActionId = x.ActionId,
                    CustomerName = x.CustomerNavigation.CustomerFirstName + " " + x.CustomerNavigation.CustomerLastName,
                    EmployeeName = x.EmployeeNavigation.EmployeeFirstName + " " + x.EmployeeNavigation.EmployeeLastName,
                    ProductSerialNumber = x.ProductSerialNumber,
                    AcceptedDate = x.AcceptedDate,
                    CompletedDate = x.CompletedDate
                }).ToList();
        }

        public ResultCustomerInfoBySerialDTO TGetCustomerInfoBySerial(string productSerialNumber)
        {
            return _context.Sales
                .Where(s => s.DataStatus != EntityLayer.Enum.DataStatus.Deleted)
                .Where(s => s.ProductSerialNumber == productSerialNumber)
                .Join(_context.Customers,
                      sale => sale.Customer,
                      customer => customer.CustomerId,
                      (sale, customer) => new ResultCustomerInfoBySerialDTO
                      {
                          CustomerId = customer.CustomerId,
                          CustomerFirstName = customer.CustomerFirstName,
                          CustomerLastName = customer.CustomerLastName,
                          SaleDate = sale.SaleDate
                      })
                .FirstOrDefault();
        }

        public bool TIsAnyActionBySerial(string productSerialNumber)
        {
            return _context.Actions.Any(a => a.ProductSerialNumber == productSerialNumber);
        }
    }
}
