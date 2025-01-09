using System;
using System.Collections.Generic;
using System.Linq;
using Tech2019.BusinessLayer.AbstractServices;
using Tech2019.DataAccessLayer.AbstractDAL;
using Tech2019.DTOLayer.CustomerDTO;
using Tech2019.DTOLayer.ProductTraceDTOs;
using Tech2019.EntityLayer.Concrete;

namespace Tech2019.BusinessLayer.ConcreteManagers
{
    public class ProductTraceManager : IProductTraceService
    {
        private readonly IProductTraceDal _productTraceDal;

        public ProductTraceManager(IProductTraceDal productTraceDal)
        {
            _productTraceDal = productTraceDal;
        }

        public void Create(ProductTrace entity)
        {
            entity.CreatedDate = DateTime.Now;
            entity.DataStatus = EntityLayer.Enum.DataStatus.Active;
            _productTraceDal.TCreate(entity);
        }

        public void Delete(ProductTrace entity)
        {
            entity.DeletedDate = DateTime.Now;
            entity.DataStatus = EntityLayer.Enum.DataStatus.Deleted;
            _productTraceDal.TDelete(entity);
        }

        public IEnumerable<ProductTrace> GetAll()
        {
            return _productTraceDal.TGetAll().Where(x => x.DataStatus != EntityLayer.Enum.DataStatus.Deleted);
        }

        public ProductTrace GetById(int id)
        {
            return _productTraceDal.TGetById(id);
        }

        public ResultCustomerInfoBySerialDTO GetCustomerInfoBySerial(string serialNumber)
        {
            return _productTraceDal.TGetCustomerInfoBySerial(serialNumber);
        }

        public List<ResultProductTraceDTO> GetProductTraceList()
        {
            return _productTraceDal.TGetProductTraceList();
        }

        public List<ProductTrace> GetProductTracesBySerial(string productSerialNumber)
        {
            return _productTraceDal.TGetProductTracesBySerial(productSerialNumber);
        }

        public void Update(ProductTrace entity)
        {
            entity.ModifiedDate = DateTime.Now;
            entity.DataStatus = EntityLayer.Enum.DataStatus.Modified;
            _productTraceDal.TUpdate(entity);
        }
    }
}