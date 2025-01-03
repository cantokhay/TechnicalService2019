using System;
using System.Collections.Generic;
using System.Linq;
using Tech2019.BusinessLayer.AbstractServices;
using Tech2019.DataAccessLayer.AbstractDAL;
using Tech2019.DTOLayer.CategoryDTOs;
using Tech2019.EntityLayer.Concrete;

namespace Tech2019.BusinessLayer.ConcreteManagers
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal context)
        {
            _categoryDal = context;
        }

        public void Create(Category entity)
        {
            entity.CreatedDate = DateTime.Now;
            entity.DataStatus = EntityLayer.Enum.DataStatus.Active;
            _categoryDal.TCreate(entity);
        }

        public void Delete(Category entity)
        {
            entity.DeletedDate = DateTime.Now;
            entity.DataStatus = EntityLayer.Enum.DataStatus.Deleted;
            _categoryDal.TDelete(entity);
        }

        public IEnumerable<Category> GetAll()
        {
            return _categoryDal.TGetAll().Where(x => x.DataStatus != EntityLayer.Enum.DataStatus.Deleted);
        }

        public Category GetById(int id)
        {
            return _categoryDal.TGetById(id);
        }

        public List<ResultCategoryDTO> GetCategories()
        {
            return _categoryDal.TGetCategories();
        }

        public string GetCategoryWithMostProduct()
        {
            return _categoryDal.TGetCategoryWithMostProduct();
        }

        public int GetTotalCategoryCount()
        {
            return _categoryDal.TGetTotalCategoryCount();
        }

        public void Update(Category entity)
        {
            entity.ModifiedDate = DateTime.Now;
            entity.DataStatus = EntityLayer.Enum.DataStatus.Modified;
            _categoryDal.TUpdate(entity);
        }
    }
}