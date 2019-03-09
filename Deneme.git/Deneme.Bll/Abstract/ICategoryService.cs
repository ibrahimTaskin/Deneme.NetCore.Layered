using System;
using System.Collections.Generic;
using System.Text;
using Deneme.Entities.Concrete;

namespace Deneme.Bll.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetList();
    }
}
