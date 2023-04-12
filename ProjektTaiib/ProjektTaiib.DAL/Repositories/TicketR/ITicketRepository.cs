using ProjektTaiib.DAL.Encje;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektTaiib.DAL.Repositories.TicketR
{
    public interface ITicketRepository
    {
        Ticket GetTicketById(int id);
        IEnumerable<Ticket> GetAllTickets();
        void AddTicket(Ticket ticket);
        void UpdateTicket(Ticket ticket);
        void DeleteTicket(Ticket ticket);
        void DeleteTicketById(int id);
        bool ExistTicket(int id);

        Task<IEnumerable<Ticket>> GetAllTicketAsync();
        Task<Ticket?> FirstOrDefaultAsync(int? id);
        Task<Ticket?> FindAsync(int? id);
    }
}
