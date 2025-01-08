using System.Collections.Generic;
using Tech2019.DTOLayer.InvoiceDTOs;
using Tech2019.EntityLayer.Concrete;

namespace Tech2019.BusinessLayer.AbstractServices
{
    public interface IInvoiceService : IGenericService<Invoice>
    {
        List<ResultInvoiceDTO> GetInvoiceList();
        List<ResultInvoiceToInvoiceDetailDTO> GetInvoiceListToInvoiceDetail();

    }
}
