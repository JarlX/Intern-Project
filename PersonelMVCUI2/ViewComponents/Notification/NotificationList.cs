using System;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace PersonelMVCUI2.ViewComponents.Notification
{
    public class NotificationList : ViewComponent
    {
        NotificationManager NM = new NotificationManager(new EfNotificationRepository());

        public IViewComponentResult Invoke()
        {
            var values = NM.GetList();
            return View(values);
        }
        
    }
}

