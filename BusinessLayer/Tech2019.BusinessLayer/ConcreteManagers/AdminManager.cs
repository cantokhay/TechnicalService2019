using System;
using System.Collections.Generic;
using System.Linq;
using Tech2019.BusinessLayer.AbstractServices;
using Tech2019.DataAccessLayer.AbstractDAL;
using Tech2019.EntityLayer.Concrete;

namespace Tech2019.BusinessLayer.ConcreteManagers
{
    public class AdminManager : IAdminService
    {
        private readonly IAdminDal _context;

        public AdminManager(IAdminDal context)
        {
            _context = context;
        }

        public void Create(Admin entity)
        {
            entity.CreatedDate = DateTime.Now;
            entity.DataStatus = EntityLayer.Enum.DataStatus.Active;
            _context.TCreate(entity);
        }

        public void Delete(Admin entity)
        {
            entity.DeletedDate = DateTime.Now;
            entity.DataStatus = EntityLayer.Enum.DataStatus.Deleted;
            _context.TDelete(entity);
        }

        public IEnumerable<Admin> GetAll()
        {
            return _context.TGetAll().Where(x => x.DataStatus != EntityLayer.Enum.DataStatus.Deleted);
        }

        public Admin GetById(int id)
        {
            return _context.TGetById(id);
        }

        public void Update(Admin entity)
        {
            entity.ModifiedDate = DateTime.Now;
            entity.DataStatus = EntityLayer.Enum.DataStatus.Modified;
            _context.TUpdate(entity);
        }
    }
}