using System;
using System.Collections.Generic;
using System.Linq;
using Tech2019.BusinessLayer.AbstractServices;
using Tech2019.DataAccessLayer.AbstractDAL;
using Tech2019.EntityLayer.Concrete;

namespace Tech2019.BusinessLayer.ConcreteManagers
{
    public class FaultDetailManager : IFaultDetailService
    {
        private readonly IFaultDetailDal _faultDetailDal;

        public FaultDetailManager(IFaultDetailDal faultDetailDal)
        {
            _faultDetailDal = faultDetailDal;
        }

        public void Create(FaultDetail entity)
        {
            entity.CreatedDate = DateTime.Now;
            entity.DataStatus = EntityLayer.Enum.DataStatus.Active;
            _faultDetailDal.TCreate(entity);
        }

        public void Delete(FaultDetail entity)
        {
            entity.DeletedDate = DateTime.Now;
            entity.DataStatus = EntityLayer.Enum.DataStatus.Deleted;
            _faultDetailDal.TDelete(entity);
        }

        public IEnumerable<FaultDetail> GetAll()
        {
            return _faultDetailDal.TGetAll().Where(x => x.DataStatus != EntityLayer.Enum.DataStatus.Deleted);
        }

        public FaultDetail GetById(int id)
        {
            return _faultDetailDal.TGetById(id);
        }

        public void Update(FaultDetail entity)
        {
            entity.ModifiedDate = DateTime.Now;
            entity.DataStatus = EntityLayer.Enum.DataStatus.Modified;
            _faultDetailDal.TUpdate(entity);
        }
    }
}