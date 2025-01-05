using System.Collections.Generic;
using Tech2019.DTOLayer.InvoiceDTOs;
using Tech2019.EntityLayer.Concrete;

namespace Tech2019.DataAccessLayer.AbstractDAL
{
    public interface IInvoiceDal : IGenericDal<Invoice>
    {
        List<ResultInvoiceDTO> TGetInvoiceList();
    }
}
