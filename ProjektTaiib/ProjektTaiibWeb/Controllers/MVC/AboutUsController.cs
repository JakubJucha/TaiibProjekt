using Microsoft.AspNetCore.Mvc;

namespace ProjektTaiibWeb.Controllers.MVC
{
    public class AboutUsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
