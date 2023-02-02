using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PersonelMVCUI2.Controllers
{
    public class MessageController : Controller
    {
        Message2Manager MM = new Message2Manager(new EfMessage2Repository());
        public IActionResult MailBox()
        {
            int id = 5;
            var values = MM.GetInboxListByWritter(5);
            return View(values);
        }

        [HttpGet]
        public IActionResult MessageDetails(int id)
        {
            var value = MM.TGetById(id);
            return View(value);
        }
    }

}
