using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.UserSecrets;
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
    [Route("api/ticket")]
    public class TicketController : Controller
    {
        private readonly ProjektTaiibDbContext _context;
        private readonly UnitOfWork unitOfWork;
        private readonly IUserRepository userRepository;
        private readonly IDetailedInformationRepository detailedInformationRepository;
        private readonly IEventRepository eventRepository;
        private readonly ITicketRepository ticketRepository;
        private readonly ISponsorRepository sponsorRepository;
        public TicketController(ProjektTaiibDbContext context, IEventRepository eventRepository, ITicketRepository ticketRepository, IUserRepository userRepository)
        {
            this.eventRepository = eventRepository;
            this.ticketRepository = ticketRepository;
            this.userRepository = userRepository;
            _context = context;
            unitOfWork = new UnitOfWork(_context, userRepository, detailedInformationRepository, eventRepository, ticketRepository, sponsorRepository);
        }
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetTicketsByUserId(int userId)
        {
            try
            {
                var user = unitOfWork.UserRepository.GetUserById(userId);

                if (user == null)
                {
                    return BadRequest("Nieprawidłowy użytkownik.");
                }

                var tickets = unitOfWork.TicketRepository.GetTicketsByUserId(userId);

                var groupedTickets = tickets.GroupBy(ticket => ticket.Event)
                    .Select(group => new
                    {
                        Event = group.Key,
                        TotalNormalTickets = group.Sum(ticket => (ticket.Type == "normal" && ticket.Premium.HasValue && !ticket.Premium.Value) ? 1 : 0),
                        TotalNormalPremiumTickets = group.Sum(ticket => (ticket.Type == "normal" && ticket.Premium.HasValue && ticket.Premium.Value) ? 1 : 0),
                        TotalReducedTickets = group.Sum(ticket => (ticket.Type == "reduced" && ticket.Premium.HasValue && !ticket.Premium.Value) ? 1 : 0),
                        TotalReducedPremiumTickets = group.Sum(ticket => (ticket.Type == "reduced" && ticket.Premium.HasValue && ticket.Premium.Value) ? 1 : 0)
                    })
                    .ToList();

                var userTicketsOnEvents = groupedTickets.Select(groupedTicket => new TicketsOnEvent
                {
                    ticketInfo = new ticketInfo
                    {
                        NormalTicket = groupedTicket.TotalNormalTickets,
                        NormalPremiumTicket = groupedTicket.TotalNormalPremiumTickets,
                        ReducedTicket = groupedTicket.TotalReducedTickets,
                        ReducedPremiumTicket = groupedTicket.TotalReducedPremiumTickets
                    },
                    events = new EventsResponse
                    {
                        Id = groupedTicket.Event.Id_event,
                        EventName = groupedTicket.Event.Event_name,
                        Date = groupedTicket.Event.Date,
                        Location = groupedTicket.Event.Location,
                        Description = groupedTicket.Event.Description,
                        Category = groupedTicket.Event.Category,
                        TicketPrice = groupedTicket.Event.Ticket_price,
                        AmountTicket = groupedTicket.Event.Amount_ticket,
                        Sponsors = groupedTicket.Event.Sponsors?.Select(s => s.Sponsor_name).ToList() ?? new List<string>()
                    }
                }).ToList();

                return Ok(userTicketsOnEvents);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Wystąpił błąd: {ex.Message}");
            }
        }

        [HttpPost("{eventId}/{userId}/buy")]
        public async Task<IActionResult> Buy(int eventId, int userId, [FromBody] TicketInfo ticketInfo)
        {
            try
            {

                var user = unitOfWork.UserRepository.GetUserById(userId);
                var ev = unitOfWork.EventRepository.GetEventById(eventId);

                if (user == null || ev == null)
                {
                    return BadRequest("Nieprawidłowe dane użytkownika lub wydarzenia.");
                }

                var tickets = new List<Ticket>();
                var normalAmount = ticketInfo.ticketInfo.NormalTicket - ticketInfo.ticketInfo.NormalPremiumTicket;
                var reducedAmount = ticketInfo.ticketInfo.ReducedTicket - ticketInfo.ticketInfo.ReducedPremiumTicket;

                if (normalAmount > 0)
                {
                    for (int i = 0; i < normalAmount; i++)
                    {
                        var normalTicket = new Ticket
                        {
                            UserId_user = userId,
                            Id_event = eventId,
                            Type = "normal",
                            Price = ticketInfo.TicketPrice,
                            Premium = false
                        };
                        tickets.Add(normalTicket);
                    }
                }

                if (ticketInfo.ticketInfo.NormalPremiumTicket > 0)
                {
                    for (int i = 0; i < ticketInfo.ticketInfo.NormalPremiumTicket; i++)
                    {
                        var normalPremiumTicket = new Ticket
                        {
                            UserId_user = userId,
                            Id_event = eventId,
                            Type = "normal",
                            Price = ticketInfo.TicketPrice * 2,
                            Premium = true
                        };
                        tickets.Add(normalPremiumTicket);
                    }
                }

                if (reducedAmount > 0)
                {
                    for (int i = 0; i < reducedAmount; i++) { 
                        var reducedTicket = new Ticket
                        {
                            UserId_user = userId,
                            Id_event = eventId,
                            Type = "reduced",
                            Price = ticketInfo.TicketPrice * 0.5,
                            Premium = false
                        };
                    tickets.Add(reducedTicket);
                    }
                }

                if (ticketInfo.ticketInfo.ReducedPremiumTicket > 0)
                {
                    for (int i = 0; i < ticketInfo.ticketInfo.ReducedPremiumTicket; i++)
                    {
                        var reducedPremiumTicket = new Ticket
                        {
                            UserId_user = userId,
                            Id_event = eventId,
                            Type = "reduced",
                            Price = ticketInfo.TicketPrice,
                            Premium = true
                        };
                        tickets.Add(reducedPremiumTicket);
                    }
                }

                foreach (Ticket t in tickets)
                {
                    unitOfWork.TicketRepository.AddTicket(t);
                    unitOfWork.SaveChanges();
                }

                ev.Amount_ticket -= ticketInfo.ticketInfo.NormalTicket + ticketInfo.ticketInfo.ReducedTicket;
                unitOfWork.SaveChanges();
                return Ok(new { Message = "Bilety zostały zakupione pomyślnie." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Wystąpił błąd: {ex.Message}");
            }
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
