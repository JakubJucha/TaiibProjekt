using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjektTaiib.DAL;
using ProjektTaiib.DAL.Encje;
using ProjektTaiib.DAL.Repositories.DetailedInformationR;
using ProjektTaiib.DAL.Repositories.EventR;
using ProjektTaiib.DAL.Repositories.SponsorR;
using ProjektTaiib.DAL.Repositories.TicketR;
using ProjektTaiib.DAL.Repositories.UserR;

namespace ProjektTaiibWeb.Controllers
{
    public class EventController : Controller
    {
        private readonly ProjektTaiibDbContext _context;
        private readonly UnitOfWork unitOfWork;
        private readonly IUserRepository userRepository;
        private readonly IDetailedInformationRepository detailedInformationRepository;
        private readonly IEventRepository eventRepository;
        private readonly ITicketRepository ticketRepository;
        private readonly ISponsorRepository sponsorRepository;

        public EventController(ProjektTaiibDbContext context)
        {
            _context = context;
            unitOfWork = new UnitOfWork(_context, userRepository, detailedInformationRepository, eventRepository, ticketRepository, sponsorRepository);
        }

        // GET: Event
        public async Task<IActionResult> Index()
        {
              return unitOfWork.EventRepository != null ? 
                          View(await unitOfWork.EventRepository.GetAllEventsAsync()) :
                          Problem("Entity set 'ProjektTaiibDbContext.Events'  is null.");
        }

        // GET: Event/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || unitOfWork.EventRepository == null)
            {
                return NotFound();
            }

            var @event = await unitOfWork.EventRepository
                .FirstOrDefaultAsync(id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // GET: Event/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Event/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_event,Event_name,Date,Location,Description,Category")] Event @event)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.EventRepository.AddEvent(@event);
                await unitOfWork.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(@event);
        }

        // GET: Event/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || unitOfWork.EventRepository== null)
            {
                return NotFound();
            }

            var @event = await unitOfWork.EventRepository.FindAsync(id);
            if (@event == null)
            {
                return NotFound();
            }
            return View(@event);
        }

        // POST: Event/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_event,Event_name,Date,Location,Description,Category")] Event @event)
        {
            if (id != @event.Id_event)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    unitOfWork.EventRepository.UpdateEvent(@event);
                    await unitOfWork.SaveAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(@event.Id_event))
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
            return View(@event);
        }

        // GET: Event/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || unitOfWork.EventRepository== null)
            {
                return NotFound();
            }

            var @event = await unitOfWork.EventRepository
                .FirstOrDefaultAsync(id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // POST: Event/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (unitOfWork.EventRepository== null)
            {
                return Problem("Entity set 'ProjektTaiibDbContext.Events'  is null.");
            }
            var @event = await unitOfWork.EventRepository.FindAsync(id);
            if (@event != null)
            {
                unitOfWork.EventRepository.DeleteEvent(@event);
            }

            await unitOfWork.SaveAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventExists(int id)
        {
          return (unitOfWork.EventRepository?.ExistEvent(id)).GetValueOrDefault();
        }
    }
}
