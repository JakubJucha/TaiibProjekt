using BLL_Business_Logic_Layer_.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjektTaiib.DAL.Encje;

namespace ProjektTaiibWeb_BLL_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventControllerAPI : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventControllerAPI(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet("category")]
        public IEnumerable<Event> EventyPoKategorii(string category)
        {
            return _eventService.GetEventsByCategory(category);
        }

        [HttpGet("date")]
        public IEnumerable<Event> EventyPoDacie(DateTime date)
        {
            return _eventService.GetEventsByDate(date);
        }
        [HttpGet("localization")]
        public IEnumerable<Event> EventyPoLokalizacji(string locale)
        {
            return _eventService.GetEventsByLocalization(locale);
        }

        [HttpGet("localization_async")]
        public async Task<IEnumerable<Event>> EventyPoLokalizacjiAsync(string locale)
        {
            Event[]? events = null;
            await Task.Factory.StartNew(() => { events = (Event[]?)_eventService.GetEventsByLocalization(locale); });
            return events;
        }
    }
}
