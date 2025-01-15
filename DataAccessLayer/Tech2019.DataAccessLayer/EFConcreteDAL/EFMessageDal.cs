using Tech2019.DataAccessLayer.AbstractDAL;
using Tech2019.DataAccessLayer.Context;
using Tech2019.EntityLayer.Concrete;

namespace Tech2019.DataAccessLayer.EFConcreteDAL
{
    public class EFMessageDal : EFGenericDal<Message>, IMessageDal
    {
        private readonly TechDBContext _context;

        public EFMessageDal(TechDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
