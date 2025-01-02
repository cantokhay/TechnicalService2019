using System;
using System.Collections.Generic;
using System.Linq;
using Tech2019.BusinessLayer.AbstractServices;
using Tech2019.DataAccessLayer.AbstractDAL;
using Tech2019.EntityLayer.Concrete;

namespace Tech2019.BusinessLayer.ConcreteManagers
{
    public class InvoiceManager : IInvoiceService
    {
        private readonly IInvoiceDal _context;

        public InvoiceManager(IInvoiceDal context)
        {
            _context = context;
        }

        public void Create(Invoice entity)
        {
            entity.CreatedDate = DateTime.Now;
            entity.DataStatus = EntityLayer.Enum.DataStatus.Active;
            _context.TCreate(entity);
        }

        public void Delete(Invoice entity)
        {
            entity.DeletedDate = DateTime.Now;
            entity.DataStatus = EntityLayer.Enum.DataStatus.Deleted;
            _context.TDelete(entity);
        }

        public IEnumerable<Invoice> GetAll()
        {
            return _context.TGetAll().Where(x => x.DataStatus != EntityLayer.Enum.DataStatus.Deleted);
        }

        public Invoice GetById(int id)
        {
            return _context.TGetById(id);
        }

        public void Update(Invoice entity)
        {
            entity.ModifiedDate = DateTime.Now;
            entity.DataStatus = EntityLayer.Enum.DataStatus.Modified;
            _context.TUpdate(entity);
        }
    }
}