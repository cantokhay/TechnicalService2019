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

        public int TGetActionCount()
        {
            return _context.Actions.Where(a => a.DataStatus != EntityLayer.Enum.DataStatus.Deleted).Count();
        }

        public int TGetActionCountByCancelledActionStatusDetail()
        {
            return _context.Actions
                .Where(a => a.DataStatus != EntityLayer.Enum.DataStatus.Deleted)
                .Where(a => a.ActionStatusDetail == EntityLayer.Enum.ActionStatusDetail.ActionCancelled)
                .Count();
        }

        public int TGetActionCountByPendingCustomerApproveActionStatusDetail()
        {
            return _context.Actions
                .Where(a => a.DataStatus != EntityLayer.Enum.DataStatus.Deleted)
                .Where(a => a.ActionStatusDetail == EntityLayer.Enum.ActionStatusDetail.PendingCustomerApprove)
                .Count();
        }

        public int TGetActionCountByPendingSparePartActionStatusDetail()
        {
            return _context.Actions
                .Where(a => a.DataStatus != EntityLayer.Enum.DataStatus.Deleted)
                .Where(a => a.ActionStatusDetail == EntityLayer.Enum.ActionStatusDetail.PendingSparePart)
                .Count();
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
                    CompletedDate = x.CompletedDate,
                    ActionStatus = x.ActionStatus,
                    ActionStatusDetail = x.ActionStatusDetail
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

        public string TGetMostFaultyProductBrand()
        {
            return _context.Actions
                .Where(s => s.DataStatus != EntityLayer.Enum.DataStatus.Deleted)
                .Join(_context.ProductTraces,
                      action => action.ProductSerialNumber,
                      trace => trace.ProductSerialNumber,
                      (action, trace) => trace.ProductSerialNumber) // Serial Number'ları al
                .Join(_context.Sales,
                      serialNumber => serialNumber,
                      sale => sale.ProductSerialNumber,
                      (serialNumber, sale) => sale.ProductNavigation.ProductBrand) // ProductNavigation ile Brand al
                .GroupBy(brand => brand) // Markaya göre grupla
                .OrderByDescending(group => group.Count()) // En çok geçen markayı sırala
                .Select(group => group.Key) // Marka ismini al
                .FirstOrDefault();
        }

        public int TGetOnRepairActionCount()
        {
            return _context.Actions
                .Where(a => a.DataStatus != EntityLayer.Enum.DataStatus.Deleted)
                .Where(a => a.ActionStatus == EntityLayer.Enum.ActionStatus.OnRepair)
                .Count();
        }

        public int TGetRepairFinishedActionCount()
        {
            return _context.Actions
                .Where(a => a.DataStatus != EntityLayer.Enum.DataStatus.Deleted)
                .Where(a => a.ActionStatus == EntityLayer.Enum.ActionStatus.RepairFinished)
                .Count();
        }

        public bool TIsAnyActionBySerial(string productSerialNumber)
        {
            return _context.Actions.Any(a => a.ProductSerialNumber == productSerialNumber);
        }
    }
}
