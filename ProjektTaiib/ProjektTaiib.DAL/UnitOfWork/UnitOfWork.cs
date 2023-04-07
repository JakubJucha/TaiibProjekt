using ProjektTaiib.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektTaiib.DAL.UnitOfWork
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
            this.context.Dispose();
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }
    }
}
