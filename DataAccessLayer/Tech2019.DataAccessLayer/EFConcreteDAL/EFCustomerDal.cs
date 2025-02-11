using System;
using System.Collections.Generic;
using System.Linq;
using Tech2019.DataAccessLayer.AbstractDAL;
using Tech2019.DataAccessLayer.Context;
using Tech2019.DTOLayer.CustomerDTO;
using Tech2019.EntityLayer.Concrete;

namespace Tech2019.DataAccessLayer.EFConcreteDAL
{
    public class EFCustomerDal : EFGenericDal<Customer>, ICustomerDal
    {
        private readonly TechDBContext _context;

        public EFCustomerDal(TechDBContext context) : base(context)
        {
            _context = context;
        }

        public List<CustomerCityDTO> TGetCustomerCityStat()
        {
            return _context.Customers
                .Where(c => c.DataStatus != EntityLayer.Enum.DataStatus.Deleted)
                .OrderBy(x => x.CustomerCity)
                .GroupBy(y => y.CustomerCity)
                .Select(z => new CustomerCityDTO
                {
                    City = z.Key,
                    Total = z.Count()
                }).ToList();
        }

        public List<CustomerCityDTO> TFillChartWithCityDatas()
        {
            return _context.Customers
                .Where(c => c.DataStatus != EntityLayer.Enum.DataStatus.Deleted)
                .GroupBy(c => c.CustomerCity)
                .Select(g => new CustomerCityDTO
                {
                    City = g.Key,
                    Total = g.Count()
                }).ToList();
        }

        public List<ResultCustomerDTO> TGetCustomers()
        {
            return _context.Customers.Where(c => c.DataStatus != EntityLayer.Enum.DataStatus.Deleted).Select(c => new ResultCustomerDTO
            {
                CustomerId = c.CustomerId,
                CustomerFirstName = c.CustomerFirstName,
                CustomerLastName = c.CustomerLastName,
                CustomerEmail = c.CustomerEmail,
                CustomerPhoneNumber = c.CustomerPhoneNumber,
                CustomerAddress = c.CustomerAddress,
                CustomerStatus = c.CustomerStatus.ToString(),
                CustomerTaxNumber = c.CustomerTaxNumber,
                CustomerTaxOffice = c.CustomerTaxOffice,
                CustomerBank = c.CustomerBank,
                CustomerCity = c.CustomerCity,
                CustomerDistrict = c.CustomerDistrict
            }).ToList();
        }

        public List<string> TGetDistinctCityList()
        {
            return _context.Customers.Where(c => c.DataStatus != EntityLayer.Enum.DataStatus.Deleted).Select(c => c.CustomerCity).Distinct().ToList();
        }

        public List<string> TGetDistinctDistrictList()
        {
            return _context.Customers.Where(c => c.DataStatus != EntityLayer.Enum.DataStatus.Deleted).Select(c => c.CustomerDistrict).Distinct().ToList();
        }

        public string TGetMostCustomerCityName()
        {
            return _context.Customers
                .Where(c => c.DataStatus != EntityLayer.Enum.DataStatus.Deleted)
                .GroupBy(c => c.CustomerCity)
                .OrderByDescending(c => c.Count())
                .Select(c => c.Key)
                .FirstOrDefault();
        }

        public int TGetTotalActiveBuyerCount()
        {
            return _context.Customers.Where(c => c.DataStatus != EntityLayer.Enum.DataStatus.Deleted).Count(c => c.CustomerStatus == EntityLayer.Enum.CustomerStatus.ActiveBuyer);
        }

        public int TGetTotalCustomerCount()
        {
            return _context.Customers.Where(c => c.DataStatus != EntityLayer.Enum.DataStatus.Deleted).Count();
        }

        public int TGetTotalDistinctCityCount()
        {
            return _context.Customers.Where(c => c.DataStatus != EntityLayer.Enum.DataStatus.Deleted).Select(c => c.CustomerCity).Distinct().Count();
        }

        public List<CustomerToSaleDTO> TGetCustomersToSale()
        {
            return _context.Customers.Select(x => new CustomerToSaleDTO
            {
                CustomerId = x.CustomerId,
                CustomerFirstName = x.CustomerFirstName,
                CustomerLastName = x.CustomerLastName
            }).ToList();
        }

        public List<CustomerToInvoiceDTO> TGetCustomersToInvoice()
        {
            return _context.Customers.Select(x => new CustomerToInvoiceDTO
            {
                CustomerId = x.CustomerId,
                CustomerFirstName = x.CustomerFirstName,
                CustomerLastName = x.CustomerLastName
            }).ToList();
        }

        public List<CustomerToHomePageDTO> TGetCustomersToHomePage()
        {
            return _context.Customers.Where(c => c.DataStatus != EntityLayer.Enum.DataStatus.Deleted).Select(x => new CustomerToHomePageDTO
            {
                CustomerEmail = x.CustomerEmail,
                CustomerFirstName = x.CustomerFirstName,
                CustomerLastName = x.CustomerLastName,
                CustomerPhoneNumber = x.CustomerPhoneNumber
            }).ToList();
        }
    }
}
