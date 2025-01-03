using System.Collections.Generic;
using Tech2019.DTOLayer.CategoryDTOs;
using Tech2019.EntityLayer.Concrete;

namespace Tech2019.DataAccessLayer.AbstractDAL
{
    public interface ICategoryDal : IGenericDal<Category>
    {
        List<ResultCategoryDTO> TGetCategories();
    }
}
