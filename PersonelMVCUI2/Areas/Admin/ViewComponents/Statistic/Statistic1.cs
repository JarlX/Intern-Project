using System;
using System.Xml.Linq;
using BusinessLayer.Concrete;
using DataAccessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;


namespace PersonelMVCUI2.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic1 : ViewComponent
    {
        BlogManager BM = new BlogManager(new EfBlogRepository());
        Context C = new Context();

       public IViewComponentResult Invoke()
        {

            ViewBag.V1 = BM.GetList().Count;
            ViewBag.V2 = C.Contacts.Count();
            ViewBag.V3 = C.Comments.Count();


            string api = "b46e96f42837404ecd941cdb032c9ea0";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=Kayseri&mode=xml&lang=tr&units=metric&appid="+api;
            XDocument document = XDocument.Load(connection);
            string value = document.Descendants("temperature").ElementAt(0).Attribute("value").Value.Trim();
            ViewBag.V4 = value;


            return View();
        }
    }
}

