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
    public class SponsorController : Controller
    {
        private readonly ProjektTaiibDbContext _context;
        private readonly UnitOfWork unitOfWork;

        public SponsorController(ProjektTaiibDbContext context)
        {
            _context = context;
            unitOfWork = new UnitOfWork(_context);
        }

        // GET: Sponsor
        public async Task<IActionResult> Index()
        {
              return unitOfWork.SponsorRepository!= null ? 
                          View(await unitOfWork.SponsorRepository.GetAllSponsorsAsync()) :
                          Problem("Entity set 'ProjektTaiibDbContext.Sponsors'  is null.");
        }

        // GET: Sponsor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || unitOfWork.SponsorRepository== null)
            {
                return NotFound();
            }

            var sponsor = await unitOfWork.SponsorRepository
                .FirstOrDefaultAsync(id);
            if (sponsor == null)
            {
                return NotFound();
            }

            return View(sponsor);
        }

        // GET: Sponsor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sponsor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_sponsor,Sponsor_name")] Sponsor sponsor)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.SponsorRepository.AddSponsor(sponsor);
                await unitOfWork.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sponsor);
        }

        // GET: Sponsor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || unitOfWork.SponsorRepository== null)
            {
                return NotFound();
            }

            var sponsor = await unitOfWork.SponsorRepository.FindAsync(id);
            if (sponsor == null)
            {
                return NotFound();
            }
            return View(sponsor);
        }

        // POST: Sponsor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_sponsor,Sponsor_name")] Sponsor sponsor)
        {
            if (id != sponsor.Id_sponsor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    unitOfWork.SponsorRepository.UpdateSponsor(sponsor);
                    await unitOfWork.SaveAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SponsorExists(sponsor.Id_sponsor))
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
            return View(sponsor);
        }

        // GET: Sponsor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || unitOfWork.SponsorRepository== null)
            {
                return NotFound();
            }

            var sponsor = await unitOfWork.SponsorRepository
                .FirstOrDefaultAsync(id);
            if (sponsor == null)
            {
                return NotFound();
            }

            return View(sponsor);
        }

        // POST: Sponsor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (unitOfWork.SponsorRepository== null)
            {
                return Problem("Entity set 'ProjektTaiibDbContext.Sponsors'  is null.");
            }
            var sponsor = await unitOfWork.SponsorRepository.FindAsync(id);
            if (sponsor != null)
            {
                unitOfWork.SponsorRepository.DeleteSponsor(sponsor);
            }
            
            await unitOfWork.SaveAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SponsorExists(int id)
        {
          return (unitOfWork.SponsorRepository?.ExistSponsor(id)).GetValueOrDefault();
        }
    }
}
