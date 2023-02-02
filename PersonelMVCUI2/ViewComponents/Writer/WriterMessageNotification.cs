using System;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace PersonelMVCUI2.ViewComponents.Writer
{
    public class WriterMessageNotification : ViewComponent
    {
        Message2Manager MM = new Message2Manager(new EfMessage2Repository());

        public IViewComponentResult Invoke()
        {
            int id = 5;
            var values = MM.GetInboxListByWritter(id);
            return View(values);
        }
       
    }
}

