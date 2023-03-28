using ProjektTaiib.DAL.Encje;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektTaiib.DAL.Repositories
{
    public interface ITicketRepository
    {
        Ticket GetTicketById(int id);
        IEnumerable<Ticket> GetAllTickets();
        //IEnumerable<Ticket> GetTicketsByEvent(int eventId);
        void AddTicket(Ticket ticket);
        void UpdateTicket(Ticket ticket);
        void DeleteTicket(Ticket ticket);
    }
}
