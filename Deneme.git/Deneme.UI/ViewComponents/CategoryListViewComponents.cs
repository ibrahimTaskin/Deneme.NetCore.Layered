using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Deneme.Bll.Abstract;
using Deneme.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace Deneme.UI.ViewComponents
{
    public class CategoryList:ViewComponent
    {
        private ICategoryService _categoryService;

        public CategoryList(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public ViewViewComponentResult Invoke()
        {
            var model = new CategoryListViewModel
            {
                Categories = _categoryService.GetList(),
                CurrentCategory = Convert.ToInt32(HttpContext.Request.Query["category"])
            };

            return View(model);
        }
    }
}
