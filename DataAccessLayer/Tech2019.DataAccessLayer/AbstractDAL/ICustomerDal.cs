using System.Collections.Generic;
using Tech2019.DTOLayer.CustomerDTO;
using Tech2019.EntityLayer.Concrete;

namespace Tech2019.DataAccessLayer.AbstractDAL
{
    public interface ICustomerDal : IGenericDal<Customer>
    {
        List<string> TGetDistinctCityList();
        List<string> TGetDistinctDistrictList();
        List<ResultCustomerDTO> TGetCustomers();
        int TGetTotalCustomerCount();
        int TGetTotalActiveBuyerCount();
        string TGetMostCustomerCityName();
        int TGetTotalDistinctCityCount();
        List<CustomerCityDTO> TGetCustomerCityStat();
        List<CustomerCityDTO> TFillChartWithCityDatas();
        List<CustomerToSaleDTO> TGetCustomersToSale();
        List<CustomerToInvoiceDTO> TGetCustomersToInvoice();
    }
}
