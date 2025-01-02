using System;
using System.Collections.Generic;
using System.Linq;
using Tech2019.BusinessLayer.AbstractServices;
using Tech2019.DataAccessLayer.AbstractDAL;

namespace Tech2019.BusinessLayer.ConcreteManagers
{
    public class ActionManager : IActionService
    {
        private readonly IActionDal _context;

        public ActionManager(IActionDal context)
        {
            _context = context;
        }

        public void Create(EntityLayer.Concrete.Action entity)
        {
            entity.CreatedDate = DateTime.Now;
            entity.DataStatus = EntityLayer.Enum.DataStatus.Active;
            _context.TCreate(entity);
        }

        public void Delete(EntityLayer.Concrete.Action entity)
        {
            entity.DeletedDate = DateTime.Now;
            entity.DataStatus = EntityLayer.Enum.DataStatus.Deleted;
            _context.TDelete(entity);
        }

        public IEnumerable<EntityLayer.Concrete.Action> GetAll()
        {
            return _context.TGetAll().Where(x => x.DataStatus != EntityLayer.Enum.DataStatus.Deleted);
        }

        public EntityLayer.Concrete.Action GetById(int id)
        {
            return _context.TGetById(id);
        }

        public void Update(EntityLayer.Concrete.Action entity)
        {
            entity.ModifiedDate = DateTime.Now;
            entity.DataStatus = EntityLayer.Enum.DataStatus.Modified;
            _context.TUpdate(entity);
        }
    }
}