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
                    InvoiceNumber = id.InvoiceNavigation.InvoiceSerialCharacter + id.InvoiceNavigation.InvoiceSerialCharacter
                }).ToList();
        }
    }
}