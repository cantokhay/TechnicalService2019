using System.Collections.Generic;
using Tech2019.DTOLayer.CustomerDTO;
using Tech2019.DTOLayer.ProductTraceDTOs;
using Tech2019.EntityLayer.Concrete;

namespace Tech2019.DataAccessLayer.AbstractDAL
{
    public interface IProductTraceDal : IGenericDal<ProductTrace>
    {
        List<ResultProductTraceDTO> TGetProductTraceList();
        ResultCustomerInfoBySerialDTO TGetCustomerInfoBySerial(string serialNumber);
    }
}
