﻿using Tech2019.DataAccessLayer.AbstractDAL;
using Tech2019.DataAccessLayer.Context;
using Tech2019.EntityLayer.Concrete;

namespace Tech2019.DataAccessLayer.EFConcreteDAL
{
    public class EFProductTraceDal : EFGenericDal<ProductTrace>, IProductTraceDal
    {
        public EFProductTraceDal(TechDBContext context) : base(context)
        {
        }
    }
}