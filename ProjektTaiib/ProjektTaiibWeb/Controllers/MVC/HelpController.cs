using Microsoft.AspNetCore.Mvc;

namespace ProjektTaiibWeb.Controllers.MVC
{
    public class helpController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
