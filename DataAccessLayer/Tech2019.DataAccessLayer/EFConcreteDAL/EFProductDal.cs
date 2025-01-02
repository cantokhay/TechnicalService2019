using System.Collections.Generic;
using System.Linq;
using Tech2019.DataAccessLayer.AbstractDAL;
using Tech2019.DataAccessLayer.Context;
using Tech2019.DTOLayer.ProductDTOs;
using Tech2019.EntityLayer.Concrete;

namespace Tech2019.DataAccessLayer.EFConcreteDAL
{
    public class EFProductDal : EFGenericDal<Product>, IProductDal
    {
        private readonly TechDBContext _context;

        public EFProductDal(TechDBContext context) : base(context)
        {
            _context = context;
        }

        public List<ProductWithCategoryDTO> TGetProductsWithCategories()
        {
            var products = _context.Products
                                   .Where(p => p.DataStatus != EntityLayer.Enum.DataStatus.Deleted)
                                   .ToList();

            var categories = _context.Categories
                                     .Where(c => c.DataStatus != EntityLayer.Enum.DataStatus.Deleted)
                                     .ToList();

            var productList = products
                .Join(categories,
                      product => product.Category,
                      category => category.CategoryId,
                      (product, category) => new ProductWithCategoryDTO
                      {
                          ProductId = product.ProductId,
                          ProductName = product.ProductName,
                          ProductBrand = product.ProductBrand,
                          ProductPurchasePrice = product.ProductPurchasePrice,
                          ProductSalePrice = product.ProductSalePrice,
                          Stock = product.Stock,
                          CategoryId = product.Category,
                          CategoryName = category.CategoryName,
                          ProductStatus = product.ProductStatus.ToString()
                      })
                .ToList();

            return productList;
        }
    }
}