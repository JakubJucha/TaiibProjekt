using Microsoft.AspNetCore.Mvc;
using ProjektTaiib.DAL.Encje;
using BLL_Business_Logic_Layer_.Services;
namespace ProjektTaiibWeb_BLL_.Controllers
{
    public class TicketControllerBLL : Controller
    {
        private readonly ITicketService _ticketService;

        public TicketControllerBLL(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }



        public IActionResult IloscBiletowDlaEventu(int eventId)
        {
            ViewBag.Ilosc = _ticketService.GetTicketCountOnEvent(eventId);
            return View();
        }

        public IActionResult BiletyNaDanyTypEventu(int eventId,string type)
        {
            ViewBag.Bilety = _ticketService.GetTicketsByTypeonEvent(eventId,type);
            return View();
        }



        public IActionResult Index()
        {
            var tickets = _ticketService.GetAllTickets();
            return View(tickets);
        }

        public IActionResult Details(int id)
        {
            var ticket = _ticketService.GetTicketById(id);
            if (ticket == null)
            {
                return NotFound();
            }
            return View(ticket);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                _ticketService.AddTicket(ticket);
                return RedirectToAction(nameof(Index));
            }
            return View(ticket);
        }

        public IActionResult Edit(int id)
        {
            var ticket = _ticketService.GetTicketById(id);
            if (ticket == null)
            {
                return NotFound();
            }
            return View(ticket);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Ticket ticket)
        {
            if (id != ticket.Id_ticket)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _ticketService.UpdateTicket(ticket);
                return RedirectToAction(nameof(Index));
            }
            return View(ticket);
        }

        public IActionResult Delete(int id)
        {
            var ticket = _ticketService.GetTicketById(id);
            if (ticket == null)
            {
                return NotFound();
            }
            return View(ticket);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var ticket = _ticketService.GetTicketById(id);
            _ticketService.DeleteTicket(ticket);
            return RedirectToAction(nameof(Index));
        }
    }
}
