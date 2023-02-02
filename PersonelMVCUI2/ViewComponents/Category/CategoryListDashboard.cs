using System;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace PersonelMVCUI2.ViewComponents.Category
{
    public class CategoryListDashboard :ViewComponent
    {
        CategoryManager CM = new CategoryManager(new EfCategoryRepository());

       public IViewComponentResult Invoke()
        {
            var values = CM.GetList();
            return View(values);
        }
    }
}

