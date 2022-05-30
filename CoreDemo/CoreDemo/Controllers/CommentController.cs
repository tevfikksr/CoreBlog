using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class CommentController : Controller
    {
        CommentManager cm = new CommentManager(new EfCommentRepository());

        public IActionResult Index()
        {
            return View();
        }

        //[HttpGet]
        //public PartialViewResult PartialAddComment()
        //{
        //    return PartialView();
        //}

        [HttpPost]
        public PartialViewResult PartialAddComment(Comment c)
        {
            c.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.CommentStatus = true;
            //c.BlogID = 6;
            cm.CommentAdd(c);
            return PartialView();
        }

        public PartialViewResult CommentListByBlog(int id)
        {
            var values = cm.GetList(id);
            return PartialView(values);
        }
    }
}
