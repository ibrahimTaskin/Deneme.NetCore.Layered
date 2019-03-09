using System;
using System.Collections.Generic;
using System.Text;
using Deneme.Core.DataAccess.EntityFrameWork;
using Deneme.Dal.Abstract;
using Deneme.Entities.Concrete;

namespace Deneme.Dal.Concrete.EntityFrameWork
{
    public class EfCategoryDal:EfEntityRepositoryBase<Category,NorthwindContext>,ICategoryDal
    {
    }
}
