using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Deneme.Bll.Abstract;
using Deneme.Entities.Concrete;
using Deneme.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Deneme.UI.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController:Controller
    {
        private IProductService _productService;
        private ICategoryService _categoryService;

        public AdminController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public ActionResult Index()
        {
            var productList = new ProductListViewModel
            {
                Products = _productService.GetList()
            };
            return View(productList);
        }

        public ActionResult Add()
        {
            var model = new ProductAddViewModel
            {
                Product = new Product(),
                Categories = _categoryService.GetList()
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.Add(product);
                TempData.Add("message", "Ürün başarıyla eklendi."); 
            }

            return RedirectToAction("Add");
        }

        public ActionResult Update(int productId)
        {
            var model = new ProductupdateViewModel
            {
                Product=_productService.GetById(productId),
                Categories=_categoryService.GetList()
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Update(Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.Update(product);
                TempData.Add("message", "Ürün Güncellendi.");
            }

            return RedirectToAction("Update");
        }

        public ActionResult Delete(int productId)
        {
            _productService.Delete(productId);
            TempData.Add("message","Ürün başarıyla silindi.");
            return RedirectToAction("Index");

        }

        

    }
}
