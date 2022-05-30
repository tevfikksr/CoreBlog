using CoreDemo.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.Controllers
{
    public class ChartController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CategoryChart()
        {
            List<CategoryClass> list = new List<CategoryClass>();
            list.Add(new CategoryClass
            {
                categoryname = "Teknoloji",
                categorycount = 10
            });
            list.Add(new CategoryClass
            {
                categoryname = "Yazılım",
                categorycount = 10
            });
            list.Add(new CategoryClass
            {
                categoryname = "Edebiyat",
                categorycount = 10
            });

            return Json(new { jsonlist = list });
        }
    }
}
