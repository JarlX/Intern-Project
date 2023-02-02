using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace PersonelMVCUI2.Controllers
{
    public class CategoryController : Controller
    {
        
        CategoryManager CM = new CategoryManager(new EfCategoryRepository());
        public IActionResult Index()
        {
            var values = CM.GetList();
            return View(values);
        }
    }
}

