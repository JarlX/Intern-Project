using System;
using DataAccessLayer.Concreate;
using Microsoft.AspNetCore.Mvc;

namespace PersonelMVCUI2.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic2:ViewComponent
    {
        Context C = new Context();

        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = C.Blogs.OrderByDescending(x=>x.BlogId).Select(x => x.BlogTitle).Take(1).FirstOrDefault();

            var blogid = C.Blogs.OrderByDescending(x => x.BlogId).Select(x => x.WriterId).Take(1).FirstOrDefault();
            ViewBag.writer = C.Writers.Where(x => x.WriterId == blogid).Select(x => x.WriterName).FirstOrDefault();
            return View();
        }
       
    }
}

