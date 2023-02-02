 using System;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace PersonelMVCUI2.Controllers
{
    public class NewsLetterController : Controller
    {
        NewsLetterManager NLM = new NewsLetterManager(new EfNewsLetterRepository());

        [HttpGet]
        public PartialViewResult SubscribeMail()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult SubscribeMail(NewsLetter p)
        {
            p.MailStatus = true;
            NLM.AddNewsLetter(p);
            return RedirectToAction("Index","Blog");
        }
    }
}

