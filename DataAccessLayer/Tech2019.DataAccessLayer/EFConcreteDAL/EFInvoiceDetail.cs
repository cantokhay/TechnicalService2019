using System.Collections.Generic;
using System.Linq;
using Tech2019.DataAccessLayer.AbstractDAL;
using Tech2019.DataAccessLayer.Context;
using Tech2019.DTOLayer.InvoiceDetailDTOs;
using Tech2019.EntityLayer.Concrete;

namespace Tech2019.DataAccessLayer.EFConcreteDAL
{
    public class EFInvoiceDetailDal : EFGenericDal<InvoiceDetail>, IInvoiceDetailDal
    {
        private readonly TechDBContext _context;

        public EFInvoiceDetailDal(TechDBContext context) : base(context)
        {
            _context = context;
        }

        public List<ResultInvoiceDetailDTO> TGetInvoiceDetailList()
        {
            return _context.InvoiceDetails.Where(id => id.DataStatus != EntityLayer.Enum.DataStatus.Deleted)
                .Select(id => new ResultInvoiceDetailDTO
                {
                    InvoiceDetailId = id.InvoiceDetailId,
                    ProductName = id.ProductName,
                    ProductSaleQuantity = id.ProductSaleQuantity,
                    ProductUnitPrice = id.ProductUnitPrice,
                    ProductTotalPrice = id.ProductTotalPrice,
                    InvoiceId = id.InvoiceNavigation.InvoiceId,
                    InvoiceNumber = id.InvoiceNavigation.InvoiceSerialCharacter + id.InvoiceNavigation.InvoiceSequenceNumber
                }).ToList();
        }

        public List<ResultInvoiceDetailDTO> TGetInvoiceDetailListByInvoiceId(int invoiceId)
        {
            return _context.InvoiceDetails.Where(id => id.DataStatus != EntityLayer.Enum.DataStatus.Deleted)
                .Select(id => new ResultInvoiceDetailDTO
                {
                    InvoiceDetailId = id.InvoiceDetailId,
                    ProductName = id.ProductName,
                    ProductSaleQuantity = id.ProductSaleQuantity,
                    ProductUnitPrice = id.ProductUnitPrice,
                    ProductTotalPrice = id.ProductTotalPrice,
                    InvoiceId = id.InvoiceNavigation.InvoiceId,
                    InvoiceNumber = id.InvoiceNavigation.InvoiceSerialCharacter + id.InvoiceNavigation.InvoiceSequenceNumber
                })
                .Where(x => x.InvoiceId == invoiceId).ToList();
        }

        public List<ResultInvoiceDetailDTO> TGetInvoiceDetailsBySerialAndSequence(string invoiceSerial, string invoiceSequence)
        {
            return _context.InvoiceDetails
                .Where(id => id.DataStatus != EntityLayer.Enum.DataStatus.Deleted)
                .Join(
                    _context.Invoices,
                    id => id.InvoiceNavigation.InvoiceId,
                    inv => inv.InvoiceId,
                    (id, inv) => new { InvoiceDetail = id, Invoice = inv }
                )
                .Where(joined => joined.Invoice.InvoiceSerialCharacter == invoiceSerial &&
                                 joined.Invoice.InvoiceSequenceNumber == invoiceSequence)
                .Select(joined => new ResultInvoiceDetailDTO
                {
                    InvoiceDetailId = joined.InvoiceDetail.InvoiceDetailId,
                    ProductName = joined.InvoiceDetail.ProductName,
                    ProductSaleQuantity = joined.InvoiceDetail.ProductSaleQuantity,
                    ProductUnitPrice = joined.InvoiceDetail.ProductUnitPrice,
                    ProductTotalPrice = joined.InvoiceDetail.ProductTotalPrice,
                    InvoiceId = joined.InvoiceDetail.InvoiceNavigation.InvoiceId,
                    InvoiceNumber = joined.Invoice.InvoiceSerialCharacter + joined.Invoice.InvoiceSequenceNumber
                })
                .ToList();
        }

    }
}