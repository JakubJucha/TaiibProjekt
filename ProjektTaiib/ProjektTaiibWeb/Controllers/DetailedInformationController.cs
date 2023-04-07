using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjektTaiib.DAL.Encje;
using ProjektTaiib.DAL.Repositories;
using ProjektTaiib.DAL.UnitOfWork;

namespace ProjektTaiibWeb.Controllers
{
    public class DetailedInformationController : Controller
    {
        private readonly ProjektTaiibDbContext _context;
        private readonly UnitOfWork unitOfWork;

        public DetailedInformationController(ProjektTaiibDbContext context)
        {
            _context = context;
            unitOfWork = new UnitOfWork(_context);
        }

        // GET: DetailedInformation
        public async Task<IActionResult> Index()
        {
            return unitOfWork.DetailedInformationRepository != null ?
                View(await unitOfWork.DetailedInformationRepository.GetAllInformationAsync()) :
                Problem("Entity set 'ProjektTaiibDbContext.DetailedInformation' is null");
        }

        // GET: DetailedInformation/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null || unitOfWork.DetailedInformationRepository == null)
            {
                return NotFound();
            }

            var detailedInformation = await unitOfWork.DetailedInformationRepository
                .FirstOrDefaultAsync(id);

            if (detailedInformation == null)
            {
                return NotFound();
            }

            return View(detailedInformation);
        }

        // GET: DetailedInformation/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DetailedInformation/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_information,UserId,Name,Surname,Email,Phone,Payment,Country,City,Zip_code,Street,House_number,Local_number,Additional_information")] DetailedInformation detailedInformation)
        {

            if (ModelState.IsValid)
            {
                unitOfWork.DetailedInformationRepository.AddInformation(detailedInformation);
                await unitOfWork.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(detailedInformation);
        }

        // GET: DetailedInformation/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || unitOfWork.DetailedInformationRepository == null)
            {
                return NotFound();
            }

            var detailedInformation = await unitOfWork.DetailedInformationRepository.FindAsync(id);
            if (detailedInformation == null)
            {
                return NotFound();
            }
            //ViewData["UserId"] = new SelectList(_context.Users, "Id_user", "Email", detailedInformation.UserId);
            return View(detailedInformation);
        }

        // POST: DetailedInformation/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_information,UserId,Name,Surname,Email,Phone,Payment,Country,City,Zip_code,Street,House_number,Local_number,Additional_information")] DetailedInformation detailedInformation)
        {
            if (id != detailedInformation.Id_information)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    unitOfWork.DetailedInformationRepository.UpdateInformation(detailedInformation);
                    await unitOfWork.SaveAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetailedInformationExists(detailedInformation.Id_information))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
          //  ViewData["UserId"] = new SelectList(_context.Users, "Id_user", "Email", detailedInformation.UserId);
            return View(detailedInformation);
        }

        // GET: DetailedInformation/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || unitOfWork.DetailedInformationRepository == null)
            {
                return NotFound();
            }

            var detailedInformation = await unitOfWork.DetailedInformationRepository
                .FirstOrDefaultAsync(id);
            if (detailedInformation == null)
            {
                return NotFound();
            }

            return View(detailedInformation);
        }

        // POST: DetailedInformation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (unitOfWork.DetailedInformationRepository == null)
            {
                return Problem("Entity set 'ProjektTaiibDbContext.DetailedInformation'  is null.");
            }
            var detailedInformation = await unitOfWork.DetailedInformationRepository.FindAsync(id);
            if (detailedInformation != null)
            {
                unitOfWork.DetailedInformationRepository.DeleteInformation(detailedInformation);
            }
            
            await unitOfWork.SaveAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetailedInformationExists(int id)
        {
          return (unitOfWork.DetailedInformationRepository?.ExistInformation(id)).GetValueOrDefault();
        }
    }
}
