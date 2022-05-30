using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterMessageNotification : ViewComponent
    {
        Context c = new Context();
        Message2Manager mm = new Message2Manager(new EfMessage2Repository());
        private readonly UserManager<AppUser> _userManager;

        public WriterMessageNotification(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var findUser = await _userManager.FindByNameAsync(User.Identity.Name);
            var writerId = c.Writers.Where(x => x.WriterEmail == findUser.Email).Select(y => y.WriterID).FirstOrDefault();

            var values = mm.GetInbox(writerId);
            return View(values);
        }
    }
}
