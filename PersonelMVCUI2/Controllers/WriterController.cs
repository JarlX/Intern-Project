using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRule;
using DataAccessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonelMVCUI2.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PersonelMVCUI2.Controllers
{
    
    public class WriterController : Controller
    {

        WriterManager WM = new WriterManager(new EfWriterRepository());
        [Authorize]
        // GET: /<controller>/
        public IActionResult Index()
        {
            var usermail = User.Identity.Name;
            ViewBag.v = usermail;
            Context C = new Context();
            var username = C.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterName).FirstOrDefault();
            ViewBag.v2 = username;
            return View();
        }

        public IActionResult WriterProfile()
        {
            return View();
        }

        public IActionResult WriterMail()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Test()
        {
            return View();
        }

        [AllowAnonymous]
        public PartialViewResult WriterNavBarPartial()
        {
            return PartialView();
        }

        [AllowAnonymous]
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }

        
        [HttpGet]
        public IActionResult WriterEditProfile()
        {
            Context C = new Context();
            var usermail = User.Identity.Name;
            var writerId = C.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterId).FirstOrDefault();
            var writervalues = WM.TGetById(writerId);
            return View(writervalues);
        }
       
        [HttpPost]
        public IActionResult WriterEditProfile(Writer p)
        {
            
            WriterValidator WV = new WriterValidator();
            ValidationResult results = WV.Validate(p);
            if (results.IsValid)
            {
                p.WriterImage = "DENEDMEMDEMDEMMDMDMEDM";
                WM.TUpdate(p);
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                foreach(var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult WriterAdd()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult WriterAdd(AddProfileImage p)
        {
            Writer W = new Writer();
            if (p.WriterImage != null)
            {
                var extension = Path.GetExtension(p.WriterImage.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                p.WriterImage.CopyTo(stream);
                W.WriterImage = newimagename;
            }
            W.WriterMail = p.WriterMail;
            W.WriterName = p.WriterName;
            W.WriterAbout = p.WriterAbout;
            W.WriterPassword = p.WriterPassword;
            W.WriterStatus = true;
            WM.TAdd(W);
            return RedirectToAction("Index", "Deashboard");
        }
    }
}

