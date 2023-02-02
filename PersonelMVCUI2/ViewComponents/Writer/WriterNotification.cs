using System;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace PersonelMVCUI2.ViewComponents.Writer
{
    public class WriterNotification : ViewComponent 
    {
        NotificationManager NM = new NotificationManager(new EfNotificationRepository());

        public IViewComponentResult Invoke()
        {
            var values = NM.GetList();
            return View(values);
        }
    }
}

