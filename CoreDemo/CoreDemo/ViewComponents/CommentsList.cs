using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents
{
    public class CommentsList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
