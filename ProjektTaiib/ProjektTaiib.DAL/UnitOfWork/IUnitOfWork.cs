using ProjektTaiib.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektTaiib.DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        IDetailedInformationRepository DetailedInformationRepository { get; }
        IEventRepository EventRepository { get; }
        ITicketRepository TicketRepository { get; }
        ISponsorRepository SponsorRepository { get; }
        void SaveChanges();
        void Dispose();
    }
}
