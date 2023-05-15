using BLL_Business_Logic_Layer_.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjektTaiib.DAL.Encje;

namespace ProjektTaiibWeb_BLL_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SponsorControllerAPI : ControllerBase
    {
        private readonly ISponsorService _sponsorService;

        public SponsorControllerAPI(ISponsorService sponsorService)
        {
            _sponsorService = sponsorService;
        }

        [HttpGet("sponsoredEvents")]
        public IEnumerable<Event> SponsorowaneEventy(int id)
        {
            return _sponsorService.GetSponsoredEvents(id);
        }
        [HttpGet("sponsorsByName")]
        public IEnumerable<Sponsor> SponsorzyPoNazwie(string name)
        {
            return _sponsorService.GetSponsorsByName(name);
        }

        [HttpGet("sponsoredEvents_async")]
        public async Task<IEnumerable<Event>> SponsorowaneEventyAsync(int id)
        {
            Event[]? events = null;
            await Task.Factory.StartNew(() => { events = (Event[]?)_sponsorService.GetSponsoredEvents(id); });
            return events;
        }
    }
}
