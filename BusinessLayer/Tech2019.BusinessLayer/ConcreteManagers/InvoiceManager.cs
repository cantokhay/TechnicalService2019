using System;
using System.Collections.Generic;
using System.Linq;
using Tech2019.BusinessLayer.AbstractServices;
using Tech2019.DataAccessLayer.AbstractDAL;
using Tech2019.DTOLayer.InvoiceDTOs;
using Tech2019.EntityLayer.Concrete;

namespace Tech2019.BusinessLayer.ConcreteManagers
{
    public class InvoiceManager : IInvoiceService
    {
        private readonly IInvoiceDal _invoiceDal;

        public InvoiceManager(IInvoiceDal invoiceDal)
        {
            _invoiceDal = invoiceDal;
        }

        public void Create(Invoice entity)
        {
            entity.CreatedDate = DateTime.Now;
            entity.DataStatus = EntityLayer.Enum.DataStatus.Active;
            _invoiceDal.TCreate(entity);
        }

        public void Delete(Invoice entity)
        {
            entity.DeletedDate = DateTime.Now;
            entity.DataStatus = EntityLayer.Enum.DataStatus.Deleted;
            _invoiceDal.TDelete(entity);
        }

        public IEnumerable<Invoice> GetAll()
        {
            return _invoiceDal.TGetAll().Where(x => x.DataStatus != EntityLayer.Enum.DataStatus.Deleted);
        }

        public Invoice GetById(int id)
        {
            return _invoiceDal.TGetById(id);
        }

        public List<ResultInvoiceDTO> GetInvoiceList()
        {
            return _invoiceDal.TGetInvoiceList();
        }

        public void Update(Invoice entity)
        {
            entity.ModifiedDate = DateTime.Now;
            entity.DataStatus = EntityLayer.Enum.DataStatus.Modified;
            _invoiceDal.TUpdate(entity);
        }
    }
}