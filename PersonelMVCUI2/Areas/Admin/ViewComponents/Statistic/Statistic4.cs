using System;
using DataAccessLayer.Concreate;
using Microsoft.AspNetCore.Mvc;

namespace PersonelMVCUI2.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic4  : ViewComponent
    {
        Context C = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = C.Admins.Where(x => x.AdminId == 1).Select(x => x.Name).FirstOrDefault();
            ViewBag.v3 = C.Admins.Where(x => x.AdminId == 1).Select(x => x.ShortDescription).FirstOrDefault();
            return View();
        }
      
    }
}

