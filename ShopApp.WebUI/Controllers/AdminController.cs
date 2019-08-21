using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopApp.Business.Abstract;
using ShopApp.Entities;
using ShopApp.WebUI.Models;

namespace ShopApp.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private IProductService _productService;
        public AdminController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Index()
        {
            return View(new ProductListModel()
            {
                Products = _productService.GetAll()
            });
        }

        [HttpGet]
        public IActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateProduct(ProductModel model)//entities bringing the product information, no need to write eachtime
        {
            var entity = new Product()
            {
                Name = model.Name,
                Price = model.Price,
                Description = model.Description, 
                ImageUrl = model.ImageUrl
            };
            _productService.Create(entity);

            return Redirect("index");
        }
        public IActionResult Edit(int id)
        {
            var entity = _productService.GetById(id);
            var model = new ProductModel()
            {
                Id = entity.Id,
                Name= entity.Name,
                Price= entity.Price,
                Description= entity.Description,
                ImageUrl= entity.ImageUrl
            };
            return View(new ProductModel());
        }
        [HttpPost]
        public IActionResult Edit(ProductModel model)
        {
            return Redirect("Index");
        }

    }
}