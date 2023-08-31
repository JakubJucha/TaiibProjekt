using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using Microsoft.EntityFrameworkCore;
using ProjektTaiib.DAL;
using ProjektTaiib.DAL.Encje;
using ProjektTaiib.DAL.Repositories.DetailedInformationR;
using ProjektTaiib.DAL.Repositories.EventR;
using ProjektTaiib.DAL.Repositories.SponsorR;
using ProjektTaiib.DAL.Repositories.TicketR;
using ProjektTaiib.DAL.Repositories.UserR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ProjektTaiibWeb.Controllers.MVC
{
    public class StatisticsController : Controller
    {
        private readonly ProjektTaiibDbContext _context;
        private readonly UnitOfWork unitOfWork;
        private readonly IUserRepository userRepository;
        private readonly IDetailedInformationRepository detailedInformationRepository;
        private readonly IEventRepository eventRepository;
        private readonly ITicketRepository ticketRepository;
        private readonly ISponsorRepository sponsorRepository;

        public StatisticsController(ProjektTaiibDbContext context,IUserRepository userRepository, IEventRepository eventRepository, ITicketRepository ticketRepository, ISponsorRepository sponsorRepository)
        {
            this.eventRepository = eventRepository;
            this.ticketRepository = ticketRepository;
            this.sponsorRepository = sponsorRepository;
            this.userRepository = userRepository;
            _context = context;
            unitOfWork = new UnitOfWork(_context, userRepository, detailedInformationRepository, eventRepository, ticketRepository, sponsorRepository);
        }
        
        public IActionResult Index()
        {
            var events = unitOfWork.EventRepository.GetEvents();
           
            var tickets = unitOfWork.TicketRepository.GetAllTickets();
            var mostPopularEventId = tickets
                .GroupBy(t => t.Id_event)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .FirstOrDefault();
            var maxTicketsForSingleEvent = tickets
                .GroupBy(t => t.Id_event)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Count())
                .FirstOrDefault();


            var mostPopularEvent = unitOfWork.EventRepository.GetEventById(mostPopularEventId);
            var users = unitOfWork.UserRepository.GetAllUsers();


            ViewBag.EventsAmount = events.Count();
            ViewBag.TicketsAmount = tickets.Count();
            ViewBag.UsersAmount = users.Count();
            ViewBag.MostPopularEventName = mostPopularEvent.Event_name;
            ViewBag.MostPopularEventTicketCount = mostPopularEvent.Event_name;
            ViewBag.MostPopularEventDate = mostPopularEvent.Date;
            ViewBag.MostPopularEventLocation = mostPopularEvent.Location;
            ViewBag.maxTicketsForSingleEvent = maxTicketsForSingleEvent;


            var sponsors = unitOfWork.SponsorRepository.GetAllSponsors();


            ViewBag.SponsorsCount = sponsors.Count();
            string sponsorNames = "";
            foreach(Sponsor s in sponsors)
            {
                sponsorNames += s.Sponsor_name + ", ";
            }
            sponsorNames = sponsorNames.Remove(sponsorNames.Length - 2, 2);
           
            ViewBag.Sponsors = sponsorNames;


            return View();
        }
    }
}
