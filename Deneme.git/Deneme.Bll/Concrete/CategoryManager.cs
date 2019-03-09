using System;
using System.Collections.Generic;
using System.Text;
using Deneme.Bll.Abstract;
using Deneme.Dal.Abstract;
using Deneme.Entities.Concrete;

namespace Deneme.Bll.Concrete
{
    public class CategoryManager:ICategoryService
    {
        private ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public List<Category> GetList()
        {
            return _categoryDal.GetList();
        }
    }
}
