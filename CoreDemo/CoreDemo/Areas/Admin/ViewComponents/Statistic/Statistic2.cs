using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic2 : ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            Blog value = c.Blogs.OrderByDescending(x => x.BlogCreateDate).ThenByDescending(x => x.BlogCreateDate).Take(1).FirstOrDefault();
            ViewBag.v1 = c.Blogs.OrderByDescending(x => x.BlogID).Select(x => x.BlogName).Take(1).FirstOrDefault();
            return View(value);
        }
    }
}
