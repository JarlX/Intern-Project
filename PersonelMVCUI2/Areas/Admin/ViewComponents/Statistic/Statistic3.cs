using System;
using DataAccessLayer.Concreate;
using Microsoft.AspNetCore.Mvc;

namespace PersonelMVCUI2.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic3 : ViewComponent
    {
        Context C = new Context();

        public IViewComponentResult Invoke()
        {
            return View();
        }
       
    }
}

