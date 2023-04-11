using BLL_Business_Logic_Layer_.Interfaces;
using Microsoft.Extensions.Logging;
using ProjektTaiib.DAL.Encje;
using ProjektTaiib.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Business_Logic_Layer_.Implementations
{
    public class BLLTicket : ITicket
    {

        private UnitOfWork unitOfWork;

        public BLLTicket(UnitOfWork unitOfWork)
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
