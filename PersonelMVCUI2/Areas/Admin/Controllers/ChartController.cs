using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PersonelMVCUI2.Areas.Admin.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PersonelMVCUI2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChartController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CategoryChart()
        {
            List<CategoryClass> list = new List<CategoryClass>();
            list.Add(new CategoryClass
            {
                categoryname="Teknoloji",
                categorycount=10
            });
            list.Add(new CategoryClass
            {
                categoryname = "Yazılım",
                categorycount = 3
            });
            list.Add(new CategoryClass
            {
                categoryname = "Spor",
                categorycount = 5
            });

            return Json(new { jsonlist = list });
        }
    }
}

