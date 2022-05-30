using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            Context c = new Context();
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var userID = c.Writers.Where(x => x.WriterEmail == usermail).Select(y => y.WriterID).FirstOrDefault();

            ViewBag.v1 = c.Blogs.Count();
            ViewBag.v2 = c.Blogs.Where(x => x.WriterID == userID).Count();
            ViewBag.v3 = c.Categories.Count();

            return View();
        }
    }
}
