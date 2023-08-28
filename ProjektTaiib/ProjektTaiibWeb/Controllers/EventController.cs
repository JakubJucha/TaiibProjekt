using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using ProjektTaiib.DAL;
using ProjektTaiib.DAL.Encje;
using ProjektTaiib.DAL.Repositories.DetailedInformationR;
using ProjektTaiib.DAL.Repositories.EventR;
using ProjektTaiib.DAL.Repositories.SponsorR;
using ProjektTaiib.DAL.Repositories.TicketR;
using ProjektTaiib.DAL.Repositories.UserR;
using ProjektTaiibWeb.DTO;

namespace ProjektTaiibWeb.Controllers
{
    [ApiController]
    [Route("api/event")]
    public class EventController : Controller
    {
        private readonly ProjektTaiibDbContext _context;
        private readonly UnitOfWork unitOfWork;
        private readonly IUserRepository userRepository;
        private readonly IDetailedInformationRepository detailedInformationRepository;
        private readonly IEventRepository eventRepository;
        private readonly ITicketRepository ticketRepository;
        private readonly ISponsorRepository sponsorRepository;

        public EventController(ProjektTaiibDbContext context, IEventRepository eventRepository, ITicketRepository ticketRepository, ISponsorRepository sponsorRepository)
        {
            this.eventRepository = eventRepository;
            this.ticketRepository = ticketRepository;
            this.sponsorRepository = sponsorRepository;
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

      

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {

                var @event = unitOfWork.EventRepository.GetEventById(id);

                if(@event == null)
                {
                    return BadRequest("Nie ma wydarzenia z podanym id!");
                }

                var eventDtos = new EventsResponse
                {
                    Id = @event.Id_event,
                    EventName = @event.Event_name,
                    Date = @event.Date,
                    Location = @event.Location,
                    Description = @event.Description,
                    Category = @event.Category,
                    TicketPrice = @event.Ticket_price,
                    AmountTicket = @event.Amount_ticket,

                };


                List<string> sponsors = new List<string>();
              

                    var query = $"SELECT s.Sponsor_name FROM Sponsors s INNER JOIN EventSponsor es ON s.Id_sponsor = es.SponsorsId_sponsor WHERE es.EventsId_event = {@event.Id_event}";

                    sponsors = _context.Sponsors.FromSqlRaw(query).Select(s => s.Sponsor_name).ToList();
                    eventDtos.Sponsors = sponsors;
                    
                




                return Ok(eventDtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Wystąpił błąd: {ex.Message}");
            }
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllEvents()
        {
            try
            {
               
                var events = await unitOfWork.EventRepository.GetAllEventsAsync();

                var eventDtos = events.Select(e => new EventsResponse
                {
                    Id = e.Id_event,
                    EventName = e.Event_name,
                    Date = e.Date,
                    Location = e.Location,
                    Description = e.Description,
                    Category = e.Category,
                    TicketPrice = e.Ticket_price,
                    AmountTicket = e.Amount_ticket,

                }).ToList();


                List<string> sponsors = new List<string>();
                int counter = 0;
                foreach (Event ev in events)
                {
                    
                    var query = $"SELECT s.Sponsor_name FROM Sponsors s INNER JOIN EventSponsor es ON s.Id_sponsor = es.SponsorsId_sponsor WHERE es.EventsId_event = {ev.Id_event}";

                    sponsors = _context.Sponsors.FromSqlRaw(query).Select(s => s.Sponsor_name).ToList();
                    eventDtos.ElementAt(counter).Sponsors = sponsors;
                    counter++;
                }
                
                


                return Ok(eventDtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Wystąpił błąd: {ex.Message}");
            }
        }

        [HttpGet("getNewest")]
        public async Task<IActionResult> GetNewestEvents()
        {
            try
            {
                DateTime now = DateTime.Now;
                var events = await unitOfWork.EventRepository.GetAllEventsAsync();

                var upcomingEvents = new List<EventsResponse>();

                foreach (var e in events)
                {
                    if (e.Date >= now)
                    {
                        var eventDto = new EventsResponse
                        {
                            Id = e.Id_event,
                            EventName = e.Event_name,
                            Date = e.Date,
                            Location = e.Location,
                            Description = e.Description,
                            Category = e.Category,
                            TicketPrice = e.Ticket_price,
                            AmountTicket = e.Amount_ticket,
                        };

                        upcomingEvents.Add(eventDto);
                    }
                }

                upcomingEvents = upcomingEvents.OrderBy(e => e.Date).Take(3).ToList();
                List<string> sponsors = new List<string>();
                int counter = 0;
                foreach (Event ev in events)
                {
                   
                    foreach (EventsResponse er in upcomingEvents)
                    {
                     
                        if (ev.Id_event == er.Id) 
                        {
                           
                            var query = $"SELECT s.Sponsor_name FROM Sponsors s INNER JOIN EventSponsor es ON s.Id_sponsor = es.SponsorsId_sponsor WHERE es.EventsId_event = {upcomingEvents.ElementAt(counter).Id}";

                            sponsors = _context.Sponsors.FromSqlRaw(query).Select(s => s.Sponsor_name).ToList();
                            upcomingEvents.ElementAt(counter).Sponsors = sponsors; counter++;
                          
                        }
                       
                    }
           

                }



                return Ok(upcomingEvents);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Wystąpił błąd: {ex.Message}");
            }
        }

        [HttpPost("add")]
        public IActionResult Create([FromBody] EventInformation eventInfo)
        {
            try
            {
                if (eventInfo == null)
                {
                    return BadRequest("Nieprawidłowe dane wydarzenia.");
                }

                var newEvent = new Event
                {
                    Event_name = eventInfo.EventName,
                    Date = eventInfo.Date,
                    Location = eventInfo.Location,
                    Description = eventInfo.Description,
                    Category = eventInfo.Category,
                    Ticket_price = eventInfo.TicketPrice,
                    Amount_ticket = eventInfo.AmountTicket,
                };

                string[] sponsorNames = eventInfo.Sponsors.Split(';');
                List<Sponsor> sponsors = new List<Sponsor>();
                foreach (string sponsorName in sponsorNames)
                {
                    Sponsor existingSponsor = unitOfWork.SponsorRepository.GetSponsorByName(sponsorName);
                    if (existingSponsor != null)
                    {
                        existingSponsor.Events = new List<Event>();
                        existingSponsor.Events.Add(newEvent);
                        sponsors.Add(existingSponsor);

                    }
                    else
                    {
                        List<Event> sponsorEvents = new List<Event>() { newEvent };
                        Sponsor newSponsor = new Sponsor { Sponsor_name = sponsorName, Events = sponsorEvents };
                        sponsors.Add(newSponsor);
                        unitOfWork.SponsorRepository.AddSponsor(newSponsor);
                    }
                }
                newEvent.Sponsors = sponsors;

                unitOfWork.EventRepository.AddEvent(newEvent);
                unitOfWork.SaveChanges();


                unitOfWork.SaveChanges();


                

                return Ok(new { Message = "Wydarzenie zostało utworzone." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Wystąpił błąd: {ex.Message}");
            }
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
