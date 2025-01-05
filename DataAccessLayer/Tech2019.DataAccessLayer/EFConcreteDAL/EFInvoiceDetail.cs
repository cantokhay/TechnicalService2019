using Tech2019.DataAccessLayer.AbstractDAL;
using Tech2019.DataAccessLayer.Context;
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
    }
}