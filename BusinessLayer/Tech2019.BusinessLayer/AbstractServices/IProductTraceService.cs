using System.Collections.Generic;
using Tech2019.DTOLayer.CustomerDTO;
using Tech2019.DTOLayer.ProductTraceDTOs;
using Tech2019.EntityLayer.Concrete;

namespace Tech2019.BusinessLayer.AbstractServices
{
    public interface IProductTraceService : IGenericService<ProductTrace>
    {
        List<ResultProductTraceDTO> GetProductTraceList();
        ResultCustomerInfoBySerialDTO GetCustomerInfoBySerial(string serialNumber); 
        List<ProductTrace> GetProductTracesBySerial(string productSerialNumber);
    }
}
