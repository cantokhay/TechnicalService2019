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

        public string TGetCheapestProduct()
        {
            return _context.Products.Where(p => p.DataStatus != EntityLayer.Enum.DataStatus.Deleted).OrderBy(x => x.ProductSalePrice).Select(y => y.ProductName).FirstOrDefault();
        }

        public string TGetMaxStockedProduct()
        {
            return _context.Products.Where(p => p.DataStatus != EntityLayer.Enum.DataStatus.Deleted).OrderByDescending(x => x.Stock).Select(y => y.ProductName).FirstOrDefault();
        }

        public string TGetMinStockedProduct()
        {
            return _context.Products.Where(p => p.DataStatus != EntityLayer.Enum.DataStatus.Deleted).OrderBy(x => x.Stock).Select(y => y.ProductName).FirstOrDefault();
        }

        public string TGetMostExpensiveProduct()
        {
            return _context.Products.Where(p => p.DataStatus != EntityLayer.Enum.DataStatus.Deleted).OrderByDescending(x => x.ProductSalePrice).Select(y => y.ProductName).FirstOrDefault();
        }

        public string TGetMostStockedBrand()
        {
            return _context.Products.Where(p => p.DataStatus != EntityLayer.Enum.DataStatus.Deleted).GroupBy(x => x.ProductBrand).OrderByDescending(y => y.Count()).Select(z => z.Key).FirstOrDefault();
        }

        public List<ProductBrandDTO> TGetProductBrandStats()
        {
            return _context.Products.Where(p => p.DataStatus != EntityLayer.Enum.DataStatus.Deleted).OrderBy(x => x.ProductBrand)
                .GroupBy(y => y.ProductBrand)
                .Select(z => new ProductBrandDTO
                {
                    Brand = z.Key,
                    Total = z.Count()
                }).ToList();
        }

        public int TGetProductCountWithCategoryNameAppliance()
        {
            return _context.Products.Where(p => p.DataStatus != EntityLayer.Enum.DataStatus.Deleted).Where(x => x.CategoryNavigation.CategoryName == "Appliance").Sum(x => x.Stock);
        }

        public int TGetProductCountWithCategoryNameComputer()
        {
            return _context.Products.Where(p => p.DataStatus != EntityLayer.Enum.DataStatus.Deleted).Where(x => x.CategoryNavigation.CategoryName == "Computer").Sum(x => x.Stock);
        }

        public int TGetProductCountWithCategoryNameGaming()
        {
            return _context.Products.Where(p => p.DataStatus != EntityLayer.Enum.DataStatus.Deleted).Where(x => x.CategoryNavigation.CategoryName == "Gaming").Sum(x => x.Stock);
        }

        public int TGetProductsOnCriticalStockLevel()
        {
            return _context.Products.Where(p => p.DataStatus != EntityLayer.Enum.DataStatus.Deleted).Count(x => x.Stock <= 20);
        }

        public List<ProductToSaleDTO> TGetProductsToSale()
        {
            return _context.Products.Where(p => p.DataStatus != EntityLayer.Enum.DataStatus.Deleted).Select(x => new ProductToSaleDTO
            {
                ProductId = x.ProductId,
                ProductName = x.ProductName
            }).ToList();
        }

        public List<ProductWithCategoryDTO> TGetProductsWithCategories()
        {
            var products = _context.Products
                                   .Where(p => p.DataStatus != EntityLayer.Enum.DataStatus.Deleted)
                                   .ToList();

            var categories = _context.Categories
                                     .Where(c => c.DataStatus != EntityLayer.Enum.DataStatus.Deleted)
                                     .ToList();

            return products
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
        }

        public int TGetTotalBrandCount()
        {
            return _context.Products.Where(p => p.DataStatus != EntityLayer.Enum.DataStatus.Deleted).Select(x => x.ProductBrand).Distinct().Count();
        }

        public int TGetTotalProductCount()
        {
            return _context.Products.Where(p => p.DataStatus != EntityLayer.Enum.DataStatus.Deleted).Count();
        }

        public int TGetTotalProductInStock()
        {
            return _context.Products.Where(p => p.DataStatus != EntityLayer.Enum.DataStatus.Deleted).Sum(x => x.Stock);
        }
    }
}