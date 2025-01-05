using System;
using System.Collections.Generic;
using System.Linq;
using Tech2019.BusinessLayer.AbstractServices;
using Tech2019.DataAccessLayer.AbstractDAL;
using Tech2019.EntityLayer.Concrete;

namespace Tech2019.BusinessLayer.ConcreteManagers
{
    public class InvoiceDetailManager : IInvoiceDetailService
    {
        private readonly IInvoiceDetailDal _invoiceDetailDal;

        public InvoiceDetailManager(IInvoiceDetailDal invoiceDetailDal)
        {
            _invoiceDetailDal = invoiceDetailDal;
        }

        public void Create(InvoiceDetail entity)
        {
            entity.CreatedDate = DateTime.Now;
            entity.DataStatus = EntityLayer.Enum.DataStatus.Active;
            _invoiceDetailDal.TCreate(entity);
        }

        public void Delete(InvoiceDetail entity)
        {
            entity.DeletedDate = DateTime.Now;
            entity.DataStatus = EntityLayer.Enum.DataStatus.Deleted;
            _invoiceDetailDal.TDelete(entity);
        }

        public IEnumerable<InvoiceDetail> GetAll()
        {
            return _invoiceDetailDal.TGetAll().Where(x => x.DataStatus != EntityLayer.Enum.DataStatus.Deleted);
        }

        public InvoiceDetail GetById(int id)
        {
            return _invoiceDetailDal.TGetById(id);
        }

        public void Update(InvoiceDetail entity)
        {
            entity.ModifiedDate = DateTime.Now;
            entity.DataStatus = EntityLayer.Enum.DataStatus.Modified;
            _invoiceDetailDal.TUpdate(entity);
        }
    }
}