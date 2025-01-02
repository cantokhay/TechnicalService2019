using System.Collections.Generic;
using Tech2019.DTOLayer.ProductDTOs;
using Tech2019.EntityLayer.Concrete;

namespace Tech2019.BusinessLayer.AbstractServices
{
    public interface IProductService : IGenericService<Product>
    {
        List<ProductWithCategoryDTO> GetProductsWithCategories();
    }
}
