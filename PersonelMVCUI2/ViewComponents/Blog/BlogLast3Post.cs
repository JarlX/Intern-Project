using System;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace PersonelMVCUI2.ViewComponents.Blog
{
    public class BlogLast3Post :ViewComponent
    {
        BlogManager BM = new BlogManager(new EfBlogRepository());

        public IViewComponentResult Invoke()
        {
            var values = BM.GetLast3Blog();
            return View(values);
        }
    }
}

