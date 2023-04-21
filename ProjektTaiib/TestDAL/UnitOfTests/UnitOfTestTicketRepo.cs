using Microsoft.EntityFrameworkCore;
using ProjektTaiib.DAL.Encje;
using ProjektTaiib.DAL.Repositories.SponsorR;
using ProjektTaiib.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjektTaiib.DAL.Repositories.TicketR;

namespace TestDAL.UnitOfTest
{
    public class UnitOfTestTicketRepo
    {
        [Fact]
        public void TestAddTicket()
        {
            var options = new DbContextOptionsBuilder<ProjektTaiibDbContext>().UseInMemoryDatabase("Testowa").Options;
            var TaiibProjektContext = new ProjektTaiibDbContext(options);
            TicketRepository ticketRepository = new TicketRepository(TaiibProjektContext);

            ticketRepository.AddTicket(new Ticket { Id_ticket = 7, Id_event = 1, Price = 200, Type = "Normalny", Premium = false });
            ticketRepository.Save();
            Assert.NotNull(ticketRepository.GetTicketById(7));


        }


        [Fact]
        public void TestDeleteEventById()
        {
            var options = new DbContextOptionsBuilder<ProjektTaiibDbContext>().UseInMemoryDatabase("Testowa").Options;
            var TaiibProjektContext = new ProjektTaiibDbContext(options);
            TicketRepository ticketRepository = new TicketRepository(TaiibProjektContext);

            ticketRepository.AddTicket(new Ticket { Id_ticket = 8, Id_event = 1, Price = 200, Type = "Normalny", Premium = false });
            ticketRepository.Save();

            ticketRepository.DeleteTicketById(8);
            ticketRepository.Save();
            Assert.Null(ticketRepository.GetTicketById(8));

        }
    }
}
