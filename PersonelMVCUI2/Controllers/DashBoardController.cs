using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PersonelMVCUI2.Controllers
{
    public class DashBoardController : Controller
    {

        BlogManager BM = new BlogManager(new EfBlogRepository());
        WriterManager WM = new WriterManager(new EfWriterRepository());

        public IActionResult Index()
        {
            Context C = new Context();
            ViewBag.V1 = C.Blogs.Count().ToString();
            ViewBag.V2 = C.Blogs.Where(x => x.WriterId == 5).Count();
            ViewBag.V3 = C.Comments.Where(x => x.WriterId == 5).Count().ToString();

            return View();
        }
    }
}
