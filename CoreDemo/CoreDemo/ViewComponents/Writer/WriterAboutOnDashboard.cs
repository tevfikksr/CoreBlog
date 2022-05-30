using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterAboutOnDashboard : ViewComponent
    {
        Context c = new Context();

        WriterManager wm = new WriterManager(new EfWriterRepository());

        private readonly UserManager<AppUser> _userManager;

        public WriterAboutOnDashboard(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IViewComponentResult Invoke()
        {
            //var userMail = User.Identity.Name;
            //var x = wm.GetWriterFilter(x => x.WriterEmail == User.Identity.Name);
            //var values = wm.GetWriterById(x.WriterID);
            //return View(values);


            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerId = c.Writers.Where(x => x.WriterEmail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var values = wm.GetWriterById(writerId);
            return View(values);
        }
    }
}
