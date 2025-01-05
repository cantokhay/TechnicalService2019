using System;
using System.Collections.Generic;
using System.Linq;
using Tech2019.BusinessLayer.AbstractServices;
using Tech2019.DataAccessLayer.AbstractDAL;
using Tech2019.DTOLayer.SaleDTOs;
using Tech2019.EntityLayer.Concrete;

namespace Tech2019.BusinessLayer.ConcreteManagers
{
    public class SaleManager : ISaleService
    {
        private readonly ISaleDal _saleDal;

        public SaleManager(ISaleDal context)
        {
            _saleDal = context;
        }

        public void Create(Sale entity)
        {
            entity.CreatedDate = DateTime.Now;
            entity.DataStatus = EntityLayer.Enum.DataStatus.Active;
            _saleDal.TCreate(entity);
        }

        public void Delete(Sale entity)
        {
            entity.DeletedDate = DateTime.Now;
            entity.DataStatus = EntityLayer.Enum.DataStatus.Deleted;
            _saleDal.TDelete(entity);
        }

        public IEnumerable<Sale> GetAll()
        {
            return _saleDal.TGetAll().Where(x => x.DataStatus != EntityLayer.Enum.DataStatus.Deleted);
        }

        public Sale GetById(int id)
        {
            return _saleDal.TGetById(id);
        }

        public List<ResultSaleDTO> GetSales()
        {
            return _saleDal.TGetSales();
        }

        public void Update(Sale entity)
        {
            entity.ModifiedDate = DateTime.Now;
            entity.DataStatus = EntityLayer.Enum.DataStatus.Modified;
            _saleDal.TUpdate(entity);
        }
    }
}