using Microsoft.AspNetCore.Mvc;
using ProjektTaiibWeb_BLL_.Models;
using System.Diagnostics;
using BLL_Business_Logic_Layer_.Services;
namespace ProjektTaiibWeb_BLL_.Controllers
{
    public class HomeControllerBLL : Controller
    {
        private readonly ILogger<HomeControllerBLL> _logger;

        public HomeControllerBLL(ILogger<HomeControllerBLL> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}