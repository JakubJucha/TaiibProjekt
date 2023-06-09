﻿using Microsoft.AspNetCore.Mvc;
using BLL_Business_Logic_Layer_.ServicesImplementations;
using ProjektTaiib.DAL;
using ProjektTaiib.DAL.Encje;
using BLL_Business_Logic_Layer_.Services;

namespace ProjektTaiibWeb_BLL_.Controllers
{
    public class DetailedInformationControllerBLL : Controller
    {
        private readonly IDetailedInformationService _detailedInformationService;

        public DetailedInformationControllerBLL(IDetailedInformationService detailedInformationService)
        {
            _detailedInformationService = detailedInformationService;
        }



       public IActionResult InformacjePoPlatnosci(string payment)
        {
            ViewBag.info = _detailedInformationService.GetInformationByPayment(payment);
            return View();
        }

        public IActionResult InformacjePoNazwiskachAlfabetycznie()
        {
            ViewBag.info = _detailedInformationService.GetInformationByAlphabeticalSurnames();
            return View();
        }






        public IActionResult Index()
        {
            var detailedInformation = _detailedInformationService.GetAllInformation();
            return View(detailedInformation);
        }

        public IActionResult Details(int id)
        {
            var detailedInformation = _detailedInformationService.GetInformationById(id);
            if (detailedInformation == null)
            {
                return NotFound();
            }
            return View(detailedInformation);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DetailedInformation detailedInformation)
        {
            if (ModelState.IsValid)
            {
                _detailedInformationService.AddInformation(detailedInformation);
                return RedirectToAction(nameof(Index));
            }
            return View(detailedInformation);
        }

        public IActionResult Edit(int id)
        {
            var detailedInformation = _detailedInformationService.GetInformationById(id);
            if (detailedInformation == null)
            {
                return NotFound();
            }
            return View(detailedInformation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, DetailedInformation detailedInformation)
        {
            if (id != detailedInformation.Id_information)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _detailedInformationService.UpdateInformation(detailedInformation);
                return RedirectToAction(nameof(Index));
            }
            return View(detailedInformation);
        }

        public IActionResult Delete(int id)
        {
            var detailedInformation = _detailedInformationService.GetInformationById(id);
            if (detailedInformation == null)
            {
                return NotFound();
            }
            return View(detailedInformation);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var detailedInformation = _detailedInformationService.GetInformationById(id);
            _detailedInformationService.DeleteInformation(detailedInformation);
            return RedirectToAction(nameof(Index));
        }
    }

}
