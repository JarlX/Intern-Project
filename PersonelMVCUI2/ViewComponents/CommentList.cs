using System;
using Microsoft.AspNetCore.Mvc;
using PersonelMVCUI2.Models;

namespace PersonelMVCUI2.ViewComponents
{
    public class CommentList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var commentvalues = new List<UserComment>
            {
                new UserComment
                {
                    ID=1,
                    UserName="Murat"
                },
                new UserComment
                {
                    ID=2,
                    UserName ="Salih"
                },
                new UserComment
                {
                    ID=3,
                    UserName="Deniz"
                }
            };
            return View(commentvalues);
        }
         
        
    }
}

