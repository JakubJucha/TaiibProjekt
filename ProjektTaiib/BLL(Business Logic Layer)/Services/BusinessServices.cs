using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjektTaiib.DAL.Repositories;
using ProjektTaiib.DAL.Encje;
using ProjektTaiib.DAL;

namespace BLL_Business_Logic_Layer_.Services
{
    public interface IDetailedInformationService
    {
        DetailedInformation GetInformationById(int id);
        IEnumerable<DetailedInformation> GetAllInformation();
        void AddInformation(DetailedInformation detailedInformation);
        void UpdateInformation(DetailedInformation detailedInformation);
        void DeleteInformation(DetailedInformation detailedInformation);
        void DeleteInformationById(int id);
        bool ExistInformation(int id);


    }
    public interface IEventService
    {
        Event GetEventById(int id);
        IEnumerable<Event> GetEvents();
        void AddEvent(Event @event);
        void UpdateEvent(Event @event);
        void DeleteEvent(Event @event);
        void DeleteEventById(int id);
        bool ExistEvent(int id);
    }

    public interface ISponsorService
    {
        Sponsor GetSponsorById(int id);
        IEnumerable<Sponsor> GetAllSponsors();
        void AddSponsor(Sponsor sponsor);
        void UpdateSponsor(Sponsor sponsor);
        void DeleteSponsor(Sponsor sponsor);
        void DeleteSponsorById(int id);
        bool ExistSponsor(int id);
    }
    public interface ITicketService
    {
        Ticket GetTicketById(int id);
        IEnumerable<Ticket> GetAllTickets();
        void AddTicket(Ticket ticket);
        void UpdateTicket(Ticket ticket);
        void DeleteTicket(Ticket ticket);
        void DeleteTicketById(int id);
        bool ExistTicket(int id);
    }
    public interface IUserService
    {
        User GetUserById(int id);

        IEnumerable<User> GetAllUsers();
        void AddUser(User user);
        void DeleteUser(User user);
        void DeleteUserById(int id);
        void UpdateUser(User user);
        bool ExistUser(int id);
    }
}