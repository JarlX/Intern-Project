using System;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace PersonelMVCUI2.ViewComponents.Comments
{
    public class CommentListByBlog :ViewComponent
    {
        CommentManager CM = new CommentManager(new EfCommentRepository());

        public IViewComponentResult Invoke(int id) 
        {
            var values = CM.GetList(id);
            return View(values);
        }
    }
}

