using ClosedXML.Excel;
using CoreDemo.Areas.Admin.Models;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        public IActionResult ExportStaticExcel()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("BlogListesi");
                worksheet.Cell(1, 1).Value = "BlogID";
                worksheet.Cell(1, 2).Value = "Blog Adı";

                int BlogRowCount = 2;
                foreach (var item in GetBlogList())
                {
                    worksheet.Cell(BlogRowCount, 1).Value = item.ID;
                    worksheet.Cell(BlogRowCount, 2).Value = item.Name;
                    BlogRowCount++;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Calisma1.xlsx");
                }
            }
        }
        public List<BlogModel> GetBlogList()
        {
            List<BlogModel> list = new List<BlogModel>
                {
                    new BlogModel{ID = 1, Name ="mvc core propje"},
                    new BlogModel {ID = 2, Name ="marstan görüntüler"},
                    new BlogModel {ID = 3, Name ="olimpiyatın detayları"},
                };
            return list;
        }
        public IActionResult BlogListExcel()
        {
            return View();
        }
        //--------------------------------------------yukarısı statik aşağısı dinamik yapı--------------------------
        public IActionResult ExportDinamicExcel()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("BlogListesi");
                worksheet.Cell(1, 1).Value = "BlogID";
                worksheet.Cell(1, 2).Value = "Blog Adı";

                int BlogRowCount = 2;
                foreach (var item in BlogTitleList())
                {
                    worksheet.Cell(BlogRowCount, 1).Value = item.ID;
                    worksheet.Cell(BlogRowCount, 2).Value = item.Name;
                    BlogRowCount++;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Calisma1.xlsx");
                }
            }
        }
        public List<BlogModel2> BlogTitleList()
        {
            List<BlogModel2> list = new List<BlogModel2>();
            using (var c = new Context())
            {
                list = c.Blogs.Select(x => new BlogModel2
                {
                    ID = x.BlogID,
                    Name = x.BlogName
                }).ToList();
            }
            return list;
        }
        public IActionResult BlogDinamicExcel()
        {
            return View();
        }
    }
}
