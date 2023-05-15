using BLL_Business_Logic_Layer_.Services;
using ProjektTaiib.DAL.Encje;
using ProjektTaiibWeb.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestControllersMVC
{
    internal class TicketsBLLMock : ITicketService
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

        public IEnumerable<Ticket> GetAllTickets()
        {
            throw new NotImplementedException();
        }

        public Ticket GetTicketById(int id)
        {
            throw new NotImplementedException();
        }

       
        public int GetTicketCountOnEvent(int eventId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ticket> GetTicketsByTypeonEvent(int eventId, string type)
        {
            throw new NotImplementedException();
        }

        public void UpdateTicket(Ticket ticket)
        {
            throw new NotImplementedException();
        }
    }
}
