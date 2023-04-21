using Microsoft.EntityFrameworkCore;
using ProjektTaiib.DAL.Encje;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektTaiib.DAL.Repositories.EventR
{
    public class EventRepository : IEventRepository
    {

        private ProjektTaiibDbContext context;

        public EventRepository(ProjektTaiibDbContext context)
        {
            this.context = context;
        }

        public void AddEvent(Event @event)
        {
            context.Events.Add(@event);
        }

        public void DeleteEvent(Event @event)
        {
            context.Events.Remove(@event);
        }

        public void DeleteEventById(int id)
        {
#pragma warning disable CS8600 // Konwertowanie literału null lub możliwej wartości null na nienullowalny typ.
            Event @event = context.Events.FirstOrDefault(a => a.Id_event == id);
#pragma warning restore CS8600 // Konwertowanie literału null lub możliwej wartości null na nienullowalny typ.
#pragma warning disable CS8604 // Możliwy argument odwołania o wartości null.
            context.Events.Remove(@event);
#pragma warning restore CS8604 // Możliwy argument odwołania o wartości null.
        }

        public bool ExistEvent(int id)
        {
            return context.Events.Any(a => a.Id_event == id);
        }

        public Event GetEventById(int id)
        {
#pragma warning disable CS8603 // Możliwe zwrócenie odwołania o wartości null.
            return context.Events.FirstOrDefault(a => a.Id_event == id);
#pragma warning restore CS8603 // Możliwe zwrócenie odwołania o wartości null.
        }

        public IEnumerable<Event> GetEvents()
        {
            return context.Events.ToList();
        }

        public void UpdateEvent(Event @event)
        {
            context.Events.Update(@event);
        }

        public async Task<Event?> FindAsync(int? id)
        {
            return await context.Events.FindAsync(id);
        }

        public async Task<Event?> FirstOrDefaultAsync(int? id)
        {
            return await context.Events.FirstOrDefaultAsync(a => a.Id_event == id);
        }

        public async Task<IEnumerable<Event>> GetAllEventsAsync()
        {
            return await context.Events.ToListAsync();
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
