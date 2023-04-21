using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjektTaiib.DAL.Encje;
using ProjektTaiib.DAL.Repositories.EventR;
namespace TestDAL
{
    internal class EventRepoDummy : IEventRepository
    {
        public void AddEvent(Event @event)
        {
            throw new NotImplementedException();
        }

        public void DeleteEvent(Event @event)
        {
            throw new NotImplementedException();
        }

        public void DeleteEventById(int id)
        {
            throw new NotImplementedException();
        }

        public bool ExistEvent(int id)
        {
            throw new NotImplementedException();
        }

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

        public Event GetEventById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Event> GetEvents()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void UpdateEvent(Event @event)
        {
            throw new NotImplementedException();
        }
    }
}
