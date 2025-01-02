using System;
using System.Collections.Generic;
using System.Linq;
using Tech2019.BusinessLayer.AbstractServices;
using Tech2019.DataAccessLayer.AbstractDAL;
using Tech2019.DTOLayer.ProductDTOs;
using Tech2019.EntityLayer.Concrete;

namespace Tech2019.BusinessLayer.ConcreteManagers
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal context)
        {
            _productDal = context;
        }

        public void Create(Product entity)
        {
            entity.CreatedDate = DateTime.Now;
            entity.DataStatus = EntityLayer.Enum.DataStatus.Active;
            _productDal.TCreate(entity);
        }

        public void Delete(Product entity)
        {
            entity.DeletedDate = DateTime.Now;
            entity.DataStatus = EntityLayer.Enum.DataStatus.Deleted;
            _productDal.TDelete(entity);
        }

        public IEnumerable<Product> GetAll()
        {
            return _productDal.TGetAll().Where(x => x.DataStatus != EntityLayer.Enum.DataStatus.Deleted);
        }

        public Product GetById(int id)
        {
            return _productDal.TGetById(id);
        }

        public List<ProductWithCategoryDTO> GetProductsWithCategories()
        {
            return _productDal.TGetProductsWithCategories();
        }

        public void Update(Product entity)
        {
            entity.ModifiedDate = DateTime.Now;
            entity.DataStatus = EntityLayer.Enum.DataStatus.Modified;
            _productDal.TUpdate(entity);
        }
    }

}