using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CoreDemo.Controllers
{
    public class MessageController : Controller
    {
        Message2Manager mm = new Message2Manager(new EfMessage2Repository());

        Context c = new Context();

        private readonly UserManager<AppUser> _userManager;

        public MessageController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> InboxAsync()
        {
            var findUser = await _userManager.FindByNameAsync(User.Identity.Name);
            var writerId = c.Writers.Where(x => x.WriterEmail == findUser.Email).Select(y => y.WriterID).FirstOrDefault();
            //var username = User.Identity.Name;
            //var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            //var writerId = c.Writers.Where(x => x.WriterEmail == usermail).Select(y => y.WriterID).FirstOrDefault();
            //int id = writerId;
            var values = mm.GetInbox(writerId);
            return View(values);
        }

        public async Task<IActionResult> SendboxAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var id = c.Writers.Where(x => x.WriterEmail == user.Email).Select(y => y.WriterID).FirstOrDefault();
            var values = mm.GetSendbox(id);
            return View(values);
        }

        [HttpGet]
        public IActionResult MessageDetails(int id)
        {

            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerId = c.Writers.Where(x => x.WriterEmail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var messageValue = mm.GetById(writerId);
            //List<SelectListItem> categoryValues = (from x in cm.GetList()
            //                                       select new SelectListItem
            //                                       {
            //                                           Text = x.CategoryName,
            //                                           Value = x.CategoryID.ToString()
            //                                       }).ToList();
            //ViewBag.cv = categoryValues;
            return View(messageValue);
        }

        [HttpGet]
        public async Task<IActionResult> SendMessageAsync()
        {
            List<SelectListItem> recieverUsers = (from x in await GetUsersAsync()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.Email.ToString(),
                                                      Value = x.Id.ToString()
                                                  }).ToList();
            ViewBag.RecieverUser = recieverUsers;
            return View();
        }
        [HttpPost]
        public IActionResult SendMessage(Message2 m)
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerId = c.Writers.Where(x => x.WriterEmail == usermail).Select(y => y.WriterID).FirstOrDefault();

            var receiver = c.Users.Where(x => x.Id == m.ReceiverID).FirstOrDefault();
            var receiverID = c.Writers.Where(x => x.WriterEmail == receiver.Email).Select(y => y.WriterID).FirstOrDefault();

            m.SenderID = writerId;
            m.ReceiverID = receiverID;
            m.Status = true;
            m.MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            mm.TAdd(m);
            return RedirectToAction("Inbox", "Message");
        }

        public async Task<List<AppUser>> GetUsersAsync()
        {
            using (var context = new Context())
            {
                return await context.Users.ToListAsync();
            }
        }
    }
}
