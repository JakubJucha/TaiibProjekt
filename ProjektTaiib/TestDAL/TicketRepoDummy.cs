using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjektTaiib.DAL.Encje;
using ProjektTaiib.DAL.Repositories.TicketR;
namespace TestDAL
{
    internal class TicketRepoDummy : ITicketRepository
    {
        public void AddTicket(Ticket ticket)
        {
            throw new NotImplementedException();
        }

        public void DeleteTicket(Ticket ticket)
        {
            throw new NotImplementedException();
        }

        public void DeleteTicketById(int id)
        {
            throw new NotImplementedException();
        }

        public bool ExistTicket(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Ticket?> FindAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<Ticket?> FirstOrDefaultAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Ticket>> GetAllTicketAsync()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ticket> GetAllTickets()
        {
            throw new NotImplementedException();
        }

        public Ticket GetTicketById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void UpdateTicket(Ticket ticket)
        {
            throw new NotImplementedException();
        }
    }
}
