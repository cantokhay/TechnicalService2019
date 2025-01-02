using Tech2019.DataAccessLayer.AbstractDAL;
using Tech2019.DataAccessLayer.Context;
using Tech2019.EntityLayer.Concrete;

namespace Tech2019.DataAccessLayer.EFConcreteDAL
{
    public class EFSaleDal : EFGenericDal<Sale>, ISaleDal
    {
        public EFSaleDal(TechDBContext context) : base(context)
        {
        }
    }
}