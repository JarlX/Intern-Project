using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClosedXML.Excel;
using DataAccessLayer.Concreate;
using Microsoft.AspNetCore.Mvc;
using PersonelMVCUI2.Areas.Admin.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PersonelMVCUI2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        // GET: /<controller>/
        public IActionResult ExportStaticExcelBlogList()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Blog");
                worksheet.Cell(1, 1).Value = "Blog ID";
                worksheet.Cell(1, 2).Value = "Blog Adı";

                int BlogRowCount = 2;
                foreach(var item in GetBlogList())
                {
                    worksheet.Cell(BlogRowCount, 1).Value = item.Id;
                    worksheet.Cell(BlogRowCount, 2).Value = item.BlogName;
                    BlogRowCount++;

                }

                using(var stream =new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Calisma1.xslx");
                }
            }
                //return View();
        }
        public List<BlogModel> GetBlogList()
        {
            List<BlogModel> BM = new List<BlogModel>
            {
                new BlogModel{Id=1,BlogName="Yazılım"},
                new BlogModel{Id=2,BlogName="Tesla Firmasının Araçları"},
                new BlogModel{Id=3,BlogName="Cod MW2 Çıktı"}
            };
            return BM;
        }

        public IActionResult BlogListExcel()
        {
            return View();
        }



        public IActionResult ExportDynamicExcelBlogList()
        {
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("Blog");
                    worksheet.Cell(1, 1).Value = "Blog ID";
                    worksheet.Cell(1, 2).Value = "Blog Adı";

                    int BlogRowCount = 2;
                    foreach (var item in BlogTitleList())
                    {
                        worksheet.Cell(BlogRowCount, 1).Value = item.Id;
                        worksheet.Cell(BlogRowCount, 2).Value = item.BlogName;
                        BlogRowCount++;

                    }

                    using (var stream = new MemoryStream())
                    {
                        workbook.SaveAs(stream);
                        var content = stream.ToArray();
                        return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Calisma1.xslx");
                    }
                }
                //return View();
            
        }

        public List<BlogModel2> BlogTitleList()
        {
            List<BlogModel2> BM = new List<BlogModel2>();
            using(var C = new Context())
            {
                BM = C.Blogs.Select(x => new BlogModel2
                {

                    Id = x.BlogId,
                    BlogName=x.BlogTitle
                }).ToList();
            }
            return BM;
        }

        public IActionResult BlogTitleListExcel()
        {
            return View();
        }

    }
}

