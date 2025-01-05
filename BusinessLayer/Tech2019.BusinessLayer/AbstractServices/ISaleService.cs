using System.Collections.Generic;
using Tech2019.DTOLayer.SaleDTOs;
using Tech2019.EntityLayer.Concrete;

namespace Tech2019.BusinessLayer.AbstractServices
{
    public interface ISaleService : IGenericService<Sale>
    {
        List<ResultSaleDTO> GetSales();
    }
}
