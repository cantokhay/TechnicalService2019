using System;
using System.Collections.Generic;
using System.Linq;
using Tech2019.BusinessLayer.AbstractServices;
using Tech2019.DataAccessLayer.AbstractDAL;
using Tech2019.EntityLayer.Concrete;

namespace Tech2019.BusinessLayer.ConcreteManagers
{
    public class SaleManager : ISaleService
    {
        private readonly ISaleDal _context;

        public SaleManager(ISaleDal context)
        {
            _context = context;
        }

        public void Create(Sale entity)
        {
            entity.CreatedDate = DateTime.Now;
            entity.DataStatus = EntityLayer.Enum.DataStatus.Active;
            _context.TCreate(entity);
        }

        public void Delete(Sale entity)
        {
            entity.DeletedDate = DateTime.Now;
            entity.DataStatus = EntityLayer.Enum.DataStatus.Deleted;
            _context.TDelete(entity);
        }

        public IEnumerable<Sale> GetAll()
        {
            return _context.TGetAll().Where(x => x.DataStatus != EntityLayer.Enum.DataStatus.Deleted);
        }

        public Sale GetById(int id)
        {
            return _context.TGetById(id);
        }

        public void Update(Sale entity)
        {
            entity.ModifiedDate = DateTime.Now;
            entity.DataStatus = EntityLayer.Enum.DataStatus.Modified;
            _context.TUpdate(entity);
        }
    }
}