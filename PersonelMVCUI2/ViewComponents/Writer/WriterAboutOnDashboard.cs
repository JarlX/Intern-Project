using System;
using BusinessLayer.Concrete;
using DataAccessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace PersonelMVCUI2.ViewComponents.Writer
{
    
    public class WriterAboutOnDashboard :ViewComponent
    {

        WriterManager WM = new WriterManager(new EfWriterRepository());

        public IViewComponentResult Invoke()
        {
            var usermail = User.Identity.Name;
            Context C = new Context();
            var writerId = C.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterId).FirstOrDefault();
            var values = WM.GetWriterById(writerId);
            return View(values);
        }
    }
}

