﻿using BLL_Business_Logic_Layer_.Services;
using ProjektTaiib.DAL;
using ProjektTaiib.DAL.Encje;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Business_Logic_Layer_.ServicesImplementations
{
    public class BLLEventService : IEventService
    {
        private UnitOfWork unitOfWork;

        public BLLEventService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void AddEvent(Event @event)
        {
            if(@event != null)
            {
                unitOfWork.EventRepository.AddEvent(@event);
            }
            else
            {
                throw new InvalidOperationException("Error");
            }
        }

        public void DeleteEvent(Event @event)
        {
            if (@event != null)
            {
                unitOfWork.EventRepository.DeleteEvent(@event);
            }
            else
            {
                throw new InvalidOperationException("Error");
            }
        }

        public void DeleteEventById(int id)
        {
            if (id <= default(int))
                throw new InvalidOperationException("Podane id nie jest poprawne");

            unitOfWork.EventRepository.DeleteEventById(id);
        }

        public bool ExistEvent(int id)
        {
            if (id <= default(int))
                throw new InvalidOperationException("Podane id nie jest poprawne");

           bool ifExists =  unitOfWork.EventRepository.ExistEvent(id);
            return ifExists;
        }

        public Event GetEventById(int id)
        {
            if (id <= default(int))
                throw new InvalidOperationException("Podane id nie jest poprawne");

           return unitOfWork.EventRepository.GetEventById(id);
        }

        public IEnumerable<Event> GetEvents()
        {
            return unitOfWork.EventRepository.GetEvents();
        }

        public IEnumerable<Event> GetEventsByCategory(string category)
        {
            return this.unitOfWork.EventRepository.GetEvents().Where(e => e.Category == category);
        }

        public IEnumerable<Event> GetEventsByDate(DateTime date)
        {
            return this.unitOfWork.EventRepository.GetEvents().Where(d => d.Date == date);
        }

        public IEnumerable<Event> GetEventsByLocalization(string locale)
        {
            return this.unitOfWork.EventRepository.GetEvents().Where(l => l.Location == locale);
        }

        public void UpdateEvent(Event @event)
        {
            if (@event != null)
            {
                unitOfWork.EventRepository.UpdateEvent(@event);
            }
            else
            {
                throw new InvalidOperationException("Error");
            }
        }
    }
}
