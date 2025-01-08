using System.Collections.Generic;
using Tech2019.DTOLayer.InvoiceDetailDTOs;
using Tech2019.EntityLayer.Concrete;

namespace Tech2019.DataAccessLayer.AbstractDAL
{
    public interface IInvoiceDetailDal : IGenericDal<InvoiceDetail>
    {
        List<ResultInvoiceDetailDTO> TGetInvoiceDetailList();

        List<ResultInvoiceDetailDTO> TGetInvoiceDetailListByInvoiceId(int invoiceId);

        List<ResultInvoiceDetailDTO> TGetInvoiceDetailsBySerialAndSequence(string invoiceSerial, string invoiceSequence);
    }
}
