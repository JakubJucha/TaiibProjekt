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


        public IUserRepository UserRepository { get; private set; }

        public IDetailedInformationRepository DetailedInformationRepository { get; private set; }

        public IEventRepository EventRepository { get; private set; }

        public ITicketRepository TicketRepository { get; private set; }

        public ISponsorRepository SponsorRepository { get; private set; }

        public UnitOfWork(ProjektTaiibDbContext context)
        {
            this.context = context;
            UserRepository = new UserRepository(this.context);
            DetailedInformationRepository = new DetailedInformationRepository(this.context);
            EventRepository = new EventRepository(this.context);
            TicketRepository = new TicketRepository(this.context);
            SponsorRepository = new SponsorRepository(this.context);
        }

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
