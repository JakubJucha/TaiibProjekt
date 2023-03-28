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
        public IUserRepository UserRepository => throw new NotImplementedException();

        public IDetailedInformationRepository DetailedInformationRepository => throw new NotImplementedException();

        public IEventRepository EventRepository => throw new NotImplementedException();

        public ITicketRepository TicketRepository => throw new NotImplementedException();

        public ISponsorRepository SponsorRepository => throw new NotImplementedException();

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
