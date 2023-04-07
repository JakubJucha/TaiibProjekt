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
    public class TicketController : Controller
    {
        private readonly ProjektTaiibDbContext _context;
        private readonly UnitOfWork unitOfWork;

        public TicketController(ProjektTaiibDbContext context)
        {
            _context = context;
            unitOfWork = new UnitOfWork(_context);
        }

        // GET: Ticket
        public async Task<IActionResult> Index()
        {
            return unitOfWork.TicketRepository != null ?
                View(await unitOfWork.TicketRepository.GetAllTicketAsync()) :
                Problem("Entity set 'ProjektTaiibDbContext.Tickets' is null");
        }

        // GET: Ticket/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || unitOfWork.TicketRepository== null)
            {
                return NotFound();
            }

            var ticket = await unitOfWork.TicketRepository
                .FirstOrDefaultAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // GET: Ticket/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ticket/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_ticket,Id_event,Type,Price,Premium")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.TicketRepository.AddTicket(ticket);
                await unitOfWork.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ticket);
        }

        // GET: Ticket/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || unitOfWork.TicketRepository== null)
            {
                return NotFound();
            }

            var ticket = await unitOfWork.TicketRepository.FindAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }
            return View(ticket);
        }

        // POST: Ticket/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_ticket,Id_event,Type,Price,Premium")] Ticket ticket)
        {
            if (id != ticket.Id_ticket)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    unitOfWork.TicketRepository.UpdateTicket(ticket);
                    await unitOfWork.SaveAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketExists(ticket.Id_ticket))
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
            return View(ticket);
        }

        // GET: Ticket/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || unitOfWork.TicketRepository== null)
            {
                return NotFound();
            }

            var ticket = await unitOfWork.TicketRepository
                .FirstOrDefaultAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // POST: Ticket/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (unitOfWork.TicketRepository== null)
            {
                return Problem("Entity set 'ProjektTaiibDbContext.Tickets'  is null.");
            }
            var ticket = await unitOfWork.TicketRepository.FindAsync(id);
            if (ticket != null)
            {
                unitOfWork.TicketRepository.DeleteTicket(ticket);
            }
            
            await unitOfWork.SaveAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TicketExists(int id)
        {
          return (unitOfWork.TicketRepository?.ExistTicket(id)).GetValueOrDefault();
        }
    }
}
