using BLL_Business_Logic_Layer_.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjektTaiib.DAL.Encje;
using System.Diagnostics.Contracts;

namespace ProjektTaiibWeb_BLL_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketControllerAPI : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketControllerAPI(ITicketService ticketService)
        {
            this._ticketService = ticketService;
        }

        [HttpGet("count")]
        public int IloscBiletowDlaEventu(int eventId)
        {
            return _ticketService.GetTicketCountOnEvent(eventId);
        }

        [HttpGet("ticketByType")]
        public IEnumerable<Ticket> BiletyNaDanyTypEventu(int eventId, string type)
        {
           return _ticketService.GetTicketsByTypeonEvent(eventId, type);    
        }

        [HttpGet("count_async")]
        public async Task<int?> IloscBiletowDlaEventuAsync(int eventId)
        {
            int? ilosc = 0;

            await Task.Factory.StartNew(() => { ilosc = _ticketService.GetTicketCountOnEvent(eventId); });

            return ilosc;
        }
    }
}
