using BLL_Business_Logic_Layer_.Services;
using Microsoft.Extensions.Logging;
using ProjektTaiib.DAL;
using ProjektTaiib.DAL.Encje;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Business_Logic_Layer_.ServicesImplementations
{
    public class BLLTicketService : ITicketService
    {

        private UnitOfWork unitOfWork;

        public BLLTicketService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void AddTicket(Ticket ticket)
        {
            if (ticket != null)
            {
                unitOfWork.TicketRepository.AddTicket(ticket);
            }
            else
            {
                throw new InvalidOperationException("Error");
            }
        }

        public void DeleteTicket(Ticket ticket)
        {
            if (ticket != null)
            {
                unitOfWork.TicketRepository.DeleteTicket(ticket);
            }
            else
            {
                throw new InvalidOperationException("Error");
            }
        }

        public void DeleteTicketById(int id)
        {
            if (id <= default(int))
                throw new InvalidOperationException("Podane id nie jest poprawne");

            unitOfWork.TicketRepository.DeleteTicketById(id);
        }

        public bool ExistTicket(int id)
        {
            if (id <= default(int))
                throw new InvalidOperationException("Podane id nie jest poprawne");

            bool ifExist = unitOfWork.TicketRepository.ExistTicket(id);
            return ifExist;
        }

        public IEnumerable<Ticket> GetAllTickets()
        {
            return unitOfWork.TicketRepository.GetAllTickets();
        }

        public Ticket GetTicketById(int id)
        {
            if (id <= default(int))
                throw new InvalidOperationException("Podane id nie jest poprawne");

            return unitOfWork.TicketRepository.GetTicketById(id);
        }

        public int GetTicketCountOnEvent(int eventId)
        {
            return this.unitOfWork.TicketRepository.GetAllTickets().Where(e => e.Id_event == eventId).Count();
        }

        public IEnumerable<Ticket> GetTicketsByTypeonEvent(int eventId, string type)
        {
            return this.unitOfWork.TicketRepository.GetAllTickets().Where(e => e.Id_event == eventId).Where(t => t.Type == type);  
        }

        public void UpdateTicket(Ticket ticket)
        {
            if (ticket != null)
            {
                unitOfWork.TicketRepository.UpdateTicket(ticket);
            }
            else
            {
                throw new InvalidOperationException("Error");
            }
        }
    }
}
