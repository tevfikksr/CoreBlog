using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using EntityLayer.Concrete;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic4 : ViewComponent
    {
        AdminManager am = new AdminManager(new EfAdminRepository());
        public IViewComponentResult Invoke()
        {
            var value = am.GetById(1);
            return View(value);
        }
    }
}
