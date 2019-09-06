using Microsoft.AspNetCore.Mvc;
using Pavilion.Business.Abstract;
using Pavilion.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pavilion.WebUI.ViewComponents
{
    public class CategoryListViewComponent : ViewComponent
    {
        private ICategoryService _categoryService;
        public CategoryListViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IViewComponentResult Invoke()
        {
            return View(new CategoryListViewModel()
            {
                SelectedCategory = RouteData.Values["category"]?.ToString(),
                // ? makes it run only if the data coming is not NULL. If it is null, It cancels the ToString
                //receiving the values from the category route, To convert object type to string adding ToString
                Categories = _categoryService.GetAll()
            });
        }
    }
}
