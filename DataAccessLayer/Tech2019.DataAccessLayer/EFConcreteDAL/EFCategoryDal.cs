﻿using System.Collections.Generic;
using System.Linq;
using Tech2019.DataAccessLayer.AbstractDAL;
using Tech2019.DataAccessLayer.Context;
using Tech2019.DTOLayer.CategoryDTOs;
using Tech2019.EntityLayer.Concrete;

namespace Tech2019.DataAccessLayer.EFConcreteDAL
{
    public class EFCategoryDal : EFGenericDal<Category>, ICategoryDal
    {
        private readonly TechDBContext _context;
        public EFCategoryDal(TechDBContext context) : base(context)
        {
            _context = context;
        }

        public List<ResultCategoryDTO> TGetCategories()
        {
            return _context.Categories
                .Where(c => c.DataStatus != EntityLayer.Enum.DataStatus.Deleted)
                .Select(item => new ResultCategoryDTO
                {
                    CategoryId = item.CategoryId,
                    CategoryName = item.CategoryName
                })
                .ToList();
        }
    }
}