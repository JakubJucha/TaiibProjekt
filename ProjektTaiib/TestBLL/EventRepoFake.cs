using ProjektTaiib.DAL.Encje;
using ProjektTaiib.DAL.Repositories.EventR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBLL
{
    internal class EventRepoFake : IEventRepository
    {
        private List<Event> events = new List<Event>();
        public void AddEvent(Event @event)
        {
            this.events.Add(@event);
        }

        public void DeleteEvent(Event @event)
        {
            if(@event != null)
            this.events.Remove(@event);
        }

        public void DeleteEventById(int id)
        {
            var ev = this.events.Find(e => e.Id_event == id);
            if(ev != null) this.events.Remove(ev);
        }

        public bool ExistEvent(int id)
        {
            return this.events.Any(e => e.Id_event == id);
        }

        public Event GetEventById(int id)
        {
            var ev = this.events.Find(e => e.Id_event == id);
            return ev;
        }

        public IEnumerable<Event> GetEvents()
        {
            return this.events;
        }

        public void UpdateEvent(Event @event)
        {
            int index = this.events.FindIndex(e => e.Id_event == @event.Id_event);
            if (index != -1) this.events[index] = @event;
        }

        //--------Async

        public Task<Event?> FindAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<Event?> FirstOrDefaultAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Event>> GetAllEventsAsync()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
