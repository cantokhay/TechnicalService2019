using System;
using System.Collections.Generic;
using System.Linq;
using Tech2019.BusinessLayer.AbstractServices;
using Tech2019.DataAccessLayer.AbstractDAL;
using Tech2019.EntityLayer.Concrete;

namespace Tech2019.BusinessLayer.ConcreteManagers
{
    public class AboutManager : IAboutService
    {
        private readonly IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void Create(About entity)
        {
            entity.CreatedDate = DateTime.Now;
            entity.DataStatus = EntityLayer.Enum.DataStatus.Active;
            _aboutDal.TCreate(entity);
        }

        public void Delete(About entity)
        {
            entity.DeletedDate = DateTime.Now;
            entity.DataStatus = EntityLayer.Enum.DataStatus.Deleted;
            _aboutDal.TDelete(entity);
        }

        public IEnumerable<About> GetAll()
        {
            return _aboutDal.TGetAll().Where(x => x.DataStatus != EntityLayer.Enum.DataStatus.Deleted);
        }

        public About GetById(int id)
        {
            return _aboutDal.TGetById(id);
        }

        public void Update(About entity)
        {
            entity.ModifiedDate = DateTime.Now;
            entity.DataStatus = EntityLayer.Enum.DataStatus.Modified;
            _aboutDal.TUpdate(entity);
        }
    }
}
