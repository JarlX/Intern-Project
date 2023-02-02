using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DataAccessLayer.Concreate;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PersonelMVCUI2.Controllers
{
    public class LoginController : Controller
    {
        
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        
        [HttpPost]
        [AllowAnonymous]
        public async Task <IActionResult> Index(Writer p)
        {
            Context C = new Context();
            var datavalue = C.Writers.FirstOrDefault(x => x.WriterMail == p.WriterMail && x.WriterPassword == p.WriterPassword);
            if(datavalue != null)
            {
                var Claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,p.WriterMail)
                };
                var UserIdentity = new ClaimsIdentity(Claims, "a");
                ClaimsPrincipal principal = new ClaimsPrincipal(UserIdentity);
                await HttpContext.SignInAsync(principal);

                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                return View();
            }
            
        }
    }
}





//Context C = new Context();
//var datavalue = C.Writers.FirstOrDefault(x => x.WriterMail == p.WriterMail && x.WriterPassword == p.WriterPassword);
//if (datavalue != null)
//{
//    HttpContext.Session.SetString("username", p.WriterMail);
//    return RedirectToAction("Index", "Blog");
//}
//else
//{
//    return View();
//}