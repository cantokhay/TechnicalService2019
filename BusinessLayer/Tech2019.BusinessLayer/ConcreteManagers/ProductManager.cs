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

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
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

        public string GetCheapestProduct()
        {
            return _productDal.TGetCheapestProduct();
        }

        public string GetMaxStockedProduct()
        {
            return _productDal.TGetMaxStockedProduct();
        }

        public string GetMinStockedProduct()
        {
            return _productDal.TGetMinStockedProduct();
        }

        public string GetMostExpensiveProduct()
        {
            return _productDal.TGetMostExpensiveProduct();
        }

        public string GetMostStockedBrand()
        {
            return _productDal.TGetMostStockedBrand();
        }

        public List<ProductBrandDTO> GetProductBrandStats()
        {
            return _productDal.TGetProductBrandStats();
        }

        public int GetProductCountWithCategoryNameAppliance()
        {
            return _productDal.TGetProductCountWithCategoryNameAppliance();
        }

        public int GetProductCountWithCategoryNameComputer()
        {
            return _productDal.TGetProductCountWithCategoryNameComputer();
        }

        public int GetProductCountWithCategoryNameGaming()
        {
            return _productDal.TGetProductCountWithCategoryNameGaming();
        }

        public int GetProductsOnCriticalStockLevel()
        {
            return _productDal.TGetProductsOnCriticalStockLevel();
        }

        public List<ProductWithCategoryDTO> GetProductsWithCategories()
        {
            return _productDal.TGetProductsWithCategories();
        }

        public int GetTotalBrandCount()
        {
            return _productDal.TGetTotalBrandCount();
        }

        public int GetTotalProductCount()
        {
            return _productDal.TGetTotalProductCount();
        }

        public int GetTotalProductInStock()
        {
            return _productDal.TGetTotalProductInStock();
        }

        public void Update(Product entity)
        {
            entity.ModifiedDate = DateTime.Now;
            entity.DataStatus = EntityLayer.Enum.DataStatus.Modified;
            _productDal.TUpdate(entity);
        }
    }

}