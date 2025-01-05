using System.Collections.Generic;
using Tech2019.DTOLayer.ProductDTOs;
using Tech2019.EntityLayer.Concrete;

namespace Tech2019.BusinessLayer.AbstractServices
{
    public interface IProductService : IGenericService<Product>
    {
        List<ProductWithCategoryDTO> GetProductsWithCategories();
        int GetTotalProductCount();
        int GetTotalProductInStock();
        int GetProductsOnCriticalStockLevel();
        string GetMaxStockedProduct();
        string GetMinStockedProduct();
        string GetMostExpensiveProduct();
        string GetCheapestProduct();
        int GetTotalBrandCount();
        string GetMostStockedBrand();
        int GetProductCountWithCategoryNameAppliance();
        int GetProductCountWithCategoryNameComputer();
        int GetProductCountWithCategoryNameGaming(); 
        List<ProductToSaleDTO> GetProductsToSale();
        List<ProductBrandDTO> GetProductBrandStats();
    }
}
