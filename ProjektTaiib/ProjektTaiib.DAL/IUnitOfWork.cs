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
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        IDetailedInformationRepository DetailedInformationRepository { get; }
        IEventRepository EventRepository { get; }
        ITicketRepository TicketRepository { get; }
        ISponsorRepository SponsorRepository { get; }
        void SaveChanges();
        Task<int> SaveAsync();
        void Dispose();
    }
}
