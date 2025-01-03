using System.Collections.Generic;
using Tech2019.DTOLayer.ProductDTOs;
using Tech2019.EntityLayer.Concrete;

namespace Tech2019.DataAccessLayer.AbstractDAL
{
    public interface IProductDal : IGenericDal<Product>
    {
        List<ProductWithCategoryDTO> TGetProductsWithCategories();
        int TGetTotalProductCount();
        int TGetTotalProductInStock();
        int TGetProductsOnCriticalStockLevel();
        string TGetMaxStockedProduct();
        string TGetMinStockedProduct();
        string TGetMostExpensiveProduct();
        string TGetCheapestProduct();
        int TGetTotalBrandCount();
        string TGetMostStockedBrand();
        int TGetProductCountWithCategoryNameAppliance();
        int TGetProductCountWithCategoryNameComputer();
        int TGetProductCountWithCategoryNameGaming();
        List<ProductBrandDTO> TGetProductBrandStats();
    }
}
