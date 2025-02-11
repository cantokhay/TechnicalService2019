using System.Collections.Generic;
using Tech2019.DTOLayer.CustomerDTO;
using Tech2019.EntityLayer.Concrete;

namespace Tech2019.BusinessLayer.AbstractServices
{
    public interface ICustomerService : IGenericService<Customer>
    {
        List<string> GetDistinctCityList();
        List<string> GetDistinctDistrictList();
        List<ResultCustomerDTO> GetCustomers();
        int GetTotalCustomerCount();
        int GetTotalActiveBuyerCount();
        string GetMostCustomerCityName();
        int GetTotalDistinctCityCount();
        List<CustomerCityDTO> GetCustomerCityStat();
        List<CustomerToSaleDTO> GetCustomersToSale();
        List<CustomerToInvoiceDTO> GetCustomersToInvoice();
        List<CustomerCityDTO> FillChartWithCityDatas();
        List<CustomerToHomePageDTO> GetCustomersToHomePage();
    }
}
