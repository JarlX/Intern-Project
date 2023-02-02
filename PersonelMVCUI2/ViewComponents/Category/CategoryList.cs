using System;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace PersonelMVCUI2.ViewComponents.Category
{
    public class CategoryList : ViewComponent
    {
        CategoryManager CL = new CategoryManager(new EfCategoryRepository());
        public IViewComponentResult Invoke()
        {
           var values = CL.GetList();
           return View(values);
        }
    }
}

