using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace PersonelMVCUI2.Controllers
{
    public class CommentController : Controller
    {
        CommentManager CM = new CommentManager(new EfCommentRepository());

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult PartialAddComment()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult PartialAddComment(Comment p)
        {
            p.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.CommentStatus = true;
            p.BlogId = 2;
            p.WriterId = 5;
            CM.CommentAdd(p);
            return PartialView();
        }

        public PartialViewResult CommentLitByBlog(int id)
        {
            var values = CM.GetList(id);
            return PartialView(values);
        }
    }
}