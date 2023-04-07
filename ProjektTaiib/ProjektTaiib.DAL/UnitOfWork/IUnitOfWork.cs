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
        Task<int> SaveAsync();
#pragma warning disable CS0108 // Składowa ukrywa dziedziczoną składową; brak słowa kluczowego new
        void Dispose();
#pragma warning restore CS0108 // Składowa ukrywa dziedziczoną składową; brak słowa kluczowego new
    }
}
