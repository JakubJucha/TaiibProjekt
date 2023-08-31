using Microsoft.AspNetCore.Mvc;

namespace ProjektTaiibWeb.Controllers.MVC
{
    public class PrivacyPolicyController : Controller
    {
        public PrivacyPolicyController() { }
        public IActionResult Index()
        {
            return View();
        }
    }
}
