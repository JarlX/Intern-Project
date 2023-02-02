using System;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace PersonelMVCUI2.ViewComponents.Blog
{
    public class BlogListDashboard :ViewComponent
    {
        BlogManager BM = new BlogManager(new EfBlogRepository());

        public IViewComponentResult Invoke()
        {
            var values = BM.GetBlogListWithCategory();
            return View(values);
        }
    }
}

