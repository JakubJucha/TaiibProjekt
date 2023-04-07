using Microsoft.EntityFrameworkCore;
using ProjektTaiib.DAL.Encje;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektTaiib.DAL.Repositories
{
    public class TicketRepository : ITicketRepository
    {

        private ProjektTaiibDbContext context;

        public TicketRepository(ProjektTaiibDbContext context)
        {
            this.context = context;
        }

        public void AddTicket(Ticket ticket)
        {
            context.Tickets.Add(ticket);
        }

        public void DeleteTicket(Ticket ticket)
        {
            context.Tickets.Remove(ticket);
        }

        public void DeleteTicketById(int id)
        {
           Ticket ticket = context.Tickets.FirstOrDefault(a => a.Id_ticket == id);
            context.Tickets.Remove(ticket);
        }

        public bool ExistTicket(int id)
        {
            return context.Tickets.Any(a => a.Id_ticket == id);
        }

        public IEnumerable<Ticket> GetAllTickets()
        {
            return context.Tickets.ToList();
        }

        public Ticket GetTicketById(int id)
        {
            return context.Tickets.FirstOrDefault(a => a.Id_ticket == id);
        }

        public void UpdateTicket(Ticket ticket)
        {
            context.Tickets.Update(ticket);
        }

        public async Task<Ticket?> FindAsync(int? id)
        {
            return await context.Tickets.FindAsync(id);
        }

        public async Task<Ticket?> FirstOrDefaultAsync(int? id)
        {
            return await context.Tickets.FirstOrDefaultAsync(a => a.Id_ticket == id);
        }

        public async Task<IEnumerable<Ticket>> GetAllTicketAsync()
        {
            return await context.Tickets.ToListAsync();
        }
    }
}
