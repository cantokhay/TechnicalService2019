using Tech2019.DataAccessLayer.AbstractDAL;
using Tech2019.DataAccessLayer.Context;
using Tech2019.EntityLayer.Concrete;

namespace Tech2019.DataAccessLayer.EFConcreteDAL
{
    public class EFExpenseDal : EFGenericDal<Expense>, IExpenseDal
    {
        private readonly TechDBContext _context;

        public EFExpenseDal(TechDBContext context) : base(context)
        {
            _context = context;
        }
    }
}