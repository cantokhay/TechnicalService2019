using System.Collections.Generic;
using Tech2019.DTOLayer.CategoryDTOs;
using Tech2019.EntityLayer.Concrete;

namespace Tech2019.BusinessLayer.AbstractServices
{
    public interface ICategoryService : IGenericService<Category>
    {
        List<ResultCategoryDTO> GetCategories();
    }
}
