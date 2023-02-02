using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PersonelMVCUI2.Areas.Admin.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860


namespace PersonelMVCUI2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WriterController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WriterList()
        {
            var JsonWriter = JsonConvert.SerializeObject(writers);
            return Json(JsonWriter);
        }

        public IActionResult WriterListById(int writerid)
        {
            var findwriters = writers.FirstOrDefault(x => x.Id == writerid);
            var JsonWriter = JsonConvert.SerializeObject(findwriters);
            return Json(JsonWriter);
        }

        public static List<WriterClass> writers = new List<WriterClass>
        {
            new WriterClass
            {
                Id=1,
                Name="Salih"
            },
            new WriterClass
            {
                Id=2,
                Name="Deniz"
            },
            new WriterClass
            {
                Id=3,
                Name="Alper"
            },
            new WriterClass
            {
                Id=4,
                Name="Mehmet"
            }
        };
    }
}

