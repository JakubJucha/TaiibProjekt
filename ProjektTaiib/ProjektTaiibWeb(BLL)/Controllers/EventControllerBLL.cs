using Microsoft.AspNetCore.Mvc;
using BLL_Business_Logic_Layer_.Interfaces;
using ProjektTaiib.DAL.Encje;

namespace ProjektTaiibWeb_BLL_.Controllers
{
    public class EventControllerBLL : Controller
    {
        private readonly IEventService _eventService;

        public EventControllerBLL(IEventService eventService)
        {
            _eventService = eventService;
        }

        public IActionResult Index()
        {
            var events = _eventService.GetEvents();
            return View(events);
        }

        public IActionResult Details(int id)
        {
            var @event = _eventService.GetEventById(id);
            if (@event == null)
            {
                return NotFound();
            }
            return View(@event);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Event @event)
        {
            if (ModelState.IsValid)
            {
                _eventService.AddEvent(@event);
                return RedirectToAction(nameof(Index));
            }
            return View(@event);
        }

        public IActionResult Edit(int id)
        {
            var @event = _eventService.GetEventById(id);
            if (@event == null)
            {
                return NotFound();
            }
            return View(@event);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Event @event)
        {
            if (id != @event.Id_event)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _eventService.UpdateEvent(@event);
                return RedirectToAction(nameof(Index));
            }
            return View(@event);
        }

        public IActionResult Delete(int id)
        {
            var @event = _eventService.GetEventById(id);
            if (@event == null)
            {
                return NotFound();
            }
            return View(@event);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var @event = _eventService.GetEventById(id);
            _eventService.DeleteEvent(@event);
            return RedirectToAction(nameof(Index));
        }
    }
}