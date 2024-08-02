using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Areas.Admin.Controllers
{
    public class HomeController : AdminControllerBase

    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
