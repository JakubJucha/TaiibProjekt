using ProjektTaiib.DAL.Encje;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektTaiib.DAL.Repositories
{
    public interface IEventRepository
    {
        Event GetEventById(int id);
        IEnumerable<Event> GetEvents();
        void AddEvent(Event @event); 
        void UpdateEvent(Event @event);
        void DeleteEvent(Event @event);
        void DeleteEventById(int id);
        bool ExistEvent(int id);
    }
}
