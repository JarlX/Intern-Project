 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRule;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace PersonelMVCUI2.Controllers
{
    public class RegisterController : Controller
    {

        WriterManager WM = new WriterManager(new EfWriterRepository());


        [HttpGet]//Ekleme işlemi yapılırken httpget ve httppost attributlerin tanımlandığı metotlar aynı olmak zorunda.
        public IActionResult Index()
        {
            return View();                //HttpGet komutu sayfada katogerize veya benzeri işlemler kullanılırken sayfa yüklendiği anda listenmesi istenen nitelikte kullanılabilir.
                                                                                                   
        }
        [HttpPost]
        public IActionResult Index(Writer p)
        {

            WriterValidator WV = new WriterValidator();
            ValidationResult results = WV.Validate(p);

            if (results.IsValid)
            {
                
                
                p.WriterAbout = "Deneme Test";
                p.WriterImage = "Deneme Resim";
                WM.TAdd(p);
                return RedirectToAction("Index", "Blog");
                
                
              
            }
            else
            {
                foreach(var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }


          
        }

       
       
    }
}

