using Microsoft.EntityFrameworkCore;
using ProjektTaiib.DAL.Repositories.DetailedInformationR;
using ProjektTaiib.DAL.Repositories.EventR;
using ProjektTaiib.DAL.Repositories.SponsorR;
using ProjektTaiib.DAL.Repositories.TicketR;
using ProjektTaiib.DAL.Repositories.UserR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektTaiib.DAL
{
    public class UnitOfWork : IUnitOfWork
    {

        private ProjektTaiibDbContext context;


        private IUserRepository userRepository;

        private IDetailedInformationRepository detailedInformationRepository;

        private IEventRepository eventRepository ;

        private ITicketRepository ticketRepository;

        private ISponsorRepository sponsorRepository;

        public UnitOfWork(ProjektTaiibDbContext context, IUserRepository userRepository, IDetailedInformationRepository detailedInformation, 
            IEventRepository eventRepository, ITicketRepository ticketRepository, ISponsorRepository sponsorRepository)
        {
            this.context = context;
            this.userRepository = userRepository;
            this.detailedInformationRepository = detailedInformation;
            this.eventRepository = eventRepository;
            this.ticketRepository = ticketRepository;
            this.sponsorRepository = sponsorRepository;
        }

        public IUserRepository UserRepository => this.userRepository;
        public IDetailedInformationRepository DetailedInformationRepository => this.detailedInformationRepository;
        public IEventRepository EventRepository => this.eventRepository;
        public ITicketRepository TicketRepository => this.ticketRepository;
        public ISponsorRepository SponsorRepository => this.sponsorRepository;

        public void Dispose()
        {
            context.Dispose();
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await context.SaveChangesAsync();
        }
    }
}
