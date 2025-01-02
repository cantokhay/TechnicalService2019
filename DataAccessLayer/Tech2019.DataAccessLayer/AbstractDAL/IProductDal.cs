using System.Collections.Generic;
using Tech2019.DTOLayer.ProductDTOs;
using Tech2019.EntityLayer.Concrete;

namespace Tech2019.DataAccessLayer.AbstractDAL
{
    public interface IProductDal : IGenericDal<Product>
    {
        List<ProductWithCategoryDTO> TGetProductsWithCategories();
    }
}
