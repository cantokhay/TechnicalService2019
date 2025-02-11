using System;
using System.Collections.Generic;
using System.Linq;
using Tech2019.BusinessLayer.AbstractServices;
using Tech2019.DataAccessLayer.AbstractDAL;
using Tech2019.DTOLayer.CustomerDTO;
using Tech2019.EntityLayer.Concrete;

namespace Tech2019.BusinessLayer.ConcreteManagers
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public void Create(Customer entity)
        {
            entity.CreatedDate = DateTime.Now;
            entity.DataStatus = EntityLayer.Enum.DataStatus.Active;
            _customerDal.TCreate(entity);
        }

        public void Delete(Customer entity)
        {
            entity.DeletedDate = DateTime.Now;
            entity.DataStatus = EntityLayer.Enum.DataStatus.Deleted;
            _customerDal.TDelete(entity);
        }

        public List<CustomerCityDTO> FillChartWithCityDatas()
        {
            return _customerDal.TFillChartWithCityDatas();
        }

        public IEnumerable<Customer> GetAll()
        {
            return _customerDal.TGetAll().Where(x => x.DataStatus != EntityLayer.Enum.DataStatus.Deleted);
        }

        public Customer GetById(int id)
        {
            return _customerDal.TGetById(id);
        }

        public List<CustomerCityDTO> GetCustomerCityStat()
        {
            return _customerDal.TGetCustomerCityStat();
        }

        public List<ResultCustomerDTO> GetCustomers()
        {
            return _customerDal.TGetCustomers();
        }

        public List<CustomerToHomePageDTO> GetCustomersToHomePage()
        {
            return _customerDal.TGetCustomersToHomePage();
        }

        public List<CustomerToInvoiceDTO> GetCustomersToInvoice()
        {
            return _customerDal.TGetCustomersToInvoice();
        }

        public List<CustomerToSaleDTO> GetCustomersToSale()
        {
            return _customerDal.TGetCustomersToSale();
        }

        public List<string> GetDistinctCityList()
        {
            return _customerDal.TGetDistinctCityList();
        }

        public List<string> GetDistinctDistrictList()
        {
            return _customerDal.TGetDistinctDistrictList();
        }

        public string GetMostCustomerCityName()
        {
            return _customerDal.TGetMostCustomerCityName();
        }

        public int GetTotalActiveBuyerCount()
        {
            return _customerDal.TGetTotalActiveBuyerCount();
        }

        public int GetTotalCustomerCount()
        {
            return _customerDal.TGetTotalCustomerCount();
        }

        public int GetTotalDistinctCityCount()
        {
            return _customerDal.TGetTotalDistinctCityCount();
        }

        public void Update(Customer entity)
        {
            entity.ModifiedDate = DateTime.Now;
            entity.DataStatus = EntityLayer.Enum.DataStatus.Modified;
            _customerDal.TUpdate(entity);
        }
    }
}