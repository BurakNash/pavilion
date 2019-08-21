﻿using System;
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
        public IActionResult ProductList()
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

            return RedirectToAction("index");
        }
        public IActionResult EditProduct(int? id) //optional
        {
            if (id == null)
            {
                return NotFound();
            }
            var entity = _productService.GetById((int)id);//nullable to int conversion

            if (entity == null)
            {
                return NotFound();
            }

            var model = new ProductModel()
           
            {
                Id = entity.Id,
                Name= entity.Name,
                Price= entity.Price,
                Description= entity.Description,
                ImageUrl= entity.ImageUrl
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult EditProduct(ProductModel model)
        {
            var entity = _productService.GetById(model.Id);
            if (entity == null)
            {
                return NotFound();
            }

            entity.Name = model.Name;
            entity.Price = model.Price;
            entity.Description = model.Description;
            entity.ImageUrl = model.ImageUrl;

            _productService.Update(entity);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteProduct (int productId)
        {
            var entity = _productService.GetById(productId);
            if (entity != null)
            {
                _productService.Delete(entity);
            }
            return RedirectToAction("Index");
        }
    }
}