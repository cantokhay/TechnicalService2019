using Tech2019.DataAccessLayer.AbstractDAL;
using Tech2019.DataAccessLayer.Context;

namespace Tech2019.DataAccessLayer.EFConcreteDAL
{
    public class EFActionDal : EFGenericDal<EntityLayer.Concrete.Action>, IActionDal
    {
        public EFActionDal(TechDBContext context) : base(context)
        {
        }
    }
}