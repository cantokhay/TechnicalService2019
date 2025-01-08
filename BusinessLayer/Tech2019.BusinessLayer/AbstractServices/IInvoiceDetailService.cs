using System.Collections.Generic;
using Tech2019.DTOLayer.InvoiceDetailDTOs;
using Tech2019.EntityLayer.Concrete;

namespace Tech2019.BusinessLayer.AbstractServices
{
    public interface IInvoiceDetailService : IGenericService<InvoiceDetail>
    {
        List<ResultInvoiceDetailDTO> GetInvoiceDetailList();
        List<ResultInvoiceDetailDTO> GetInvoiceDetailListByInvoiceId(int invoiceId);
        List<ResultInvoiceDetailDTO> GetInvoiceDetailListByInvoiceSerialAndSequence(string invoiceSerial, string invoiceSequence);

    }
}
