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
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PersonelMVCUI2.Controllers
{
    public class BlogController : Controller
    {
        CategoryManager CM = new CategoryManager(new EfCategoryRepository());
        BlogManager BM = new BlogManager(new EfBlogRepository());

        public IActionResult Index()
        {
            var values = BM.GetBlogListWithCategory();
            return View(values);
        }

        public IActionResult BlogReadAll(int id)
        {
            ViewBag.i = id;
            var model = BM.GetBlogById(id);
            return View(model);
        }

        public IActionResult BlogListByWriter()
        {
            Context C = new Context();
            var usermail = User.Identity.Name;
            var writerId = C.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterId).FirstOrDefault();
            var values = BM.GetListWithCategoryByWriter(writerId);
            return View(values);
        }

        [HttpGet]
        public IActionResult BlogAdd()
        {
            List<SelectListItem> categoryvalues = (from x in CM.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text= x.CategoryName,
                                                       Value=x.CategoryId.ToString()
                                                   }).ToList();

            ViewBag.CV = categoryvalues;

            return View();
        }

        [HttpPost]
        public IActionResult BlogAdd(Blog p)
        {
            Context C = new Context();
            var usermail = User.Identity.Name;
            var writerId = C.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterId).FirstOrDefault();
            
            BlogValidator BV = new BlogValidator();
            ValidationResult results = BV.Validate(p);
            if (results.IsValid)
            {
               
                p.BlogStatus = true;
                p.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                p.WriterId = writerId;
                BM.TAdd(p);
                return RedirectToAction("BlogListByWriter", "Blog");
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


        public IActionResult DeleteBlog(int id)
        {
            var blogvalue = BM.TGetById(id);
            BM.TDelete(blogvalue);
            return RedirectToAction("BlogListByWriter");
        }

        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            var blogvalue = BM.TGetById(id);
            List<SelectListItem> categoryvalues = (from x in CM.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();

             ViewBag.CV = categoryvalues;
             return View(blogvalue);
        }
        [HttpPost]
        public IActionResult EditBlog(Blog p)
        {
            BM.TUpdate(p);
            return RedirectToAction("BlogListByWriter");
        }
    }
}

