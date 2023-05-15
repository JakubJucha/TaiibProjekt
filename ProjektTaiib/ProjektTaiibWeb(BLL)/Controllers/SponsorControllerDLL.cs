using Microsoft.AspNetCore.Mvc;
using ProjektTaiib.DAL.Encje;
using BLL_Business_Logic_Layer_.Services;
namespace ProjektTaiibWeb_BLL_.Controllers
{
    public class SponsorController : Controller
    {
        private readonly ISponsorService _sponsorService;

        public SponsorController(ISponsorService sponsorService)
        {
            _sponsorService = sponsorService;
        }




        public IActionResult SponsorowaneEventy(int id)
        {
            ViewBag.Events = _sponsorService.GetSponsoredEvents(id);
            return View();
        }

        public IActionResult SponsorzyPoNazwie(string name)
        {
            ViewBag.Sponsors = _sponsorService.GetSponsorsByName(name);
            return View();
        }





        public IActionResult Index()
        {
            var sponsors = _sponsorService.GetAllSponsors();
            return View(sponsors);
        }

        public IActionResult Details(int id)
        {
            var sponsor = _sponsorService.GetSponsorById(id);
            if (sponsor == null)
            {
                return NotFound();
            }
            return View(sponsor);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Sponsor sponsor)
        {
            if (ModelState.IsValid)
            {
                _sponsorService.AddSponsor(sponsor);
                return RedirectToAction(nameof(Index));
            }
            return View(sponsor);
        }

        public IActionResult Edit(int id)
        {
            var sponsor = _sponsorService.GetSponsorById(id);
            if (sponsor == null)
            {
                return NotFound();
            }
            return View(sponsor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Sponsor sponsor)
        {
            if (id != sponsor.Id_sponsor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _sponsorService.UpdateSponsor(sponsor);
                return RedirectToAction(nameof(Index));
            }
            return View(sponsor);
        }

        public IActionResult Delete(int id)
        {
            var sponsor = _sponsorService.GetSponsorById(id);
            if (sponsor == null)
            {
                return NotFound();
            }
            return View(sponsor);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var sponsor = _sponsorService.GetSponsorById(id);
            _sponsorService.DeleteSponsor(sponsor);
            return RedirectToAction(nameof(Index));
        }
    }
}