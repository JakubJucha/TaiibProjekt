using Microsoft.EntityFrameworkCore;
using ProjektTaiib.DAL.Repositories.UserR;
using ProjektTaiib.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjektTaiib.DAL.Repositories.EventR;

namespace TestDAL.UnitOfTest
{
    public class UnitOfTestEventRepo
    {
       
        [Fact]
        public void TestAddEvent()
        {
            var options = new DbContextOptionsBuilder<ProjektTaiibDbContext>().UseInMemoryDatabase("Testowa").Options;
            var TaiibProjektContext = new ProjektTaiibDbContext(options);
            EventRepository eventRepository = new EventRepository(TaiibProjektContext);

            eventRepository.AddEvent(new ProjektTaiib.DAL.Encje.Event { Id_event = 3, Event_name = "Test", Date = new DateTime(2023, 11, 21, 18, 30, 00), Location = "Test, Test", Category = "Test" });
            eventRepository.Save();
            Assert.NotNull(eventRepository.GetEventById(3));


        }


        [Fact]
        public void TestDeleteEventById()
        {
            var options = new DbContextOptionsBuilder<ProjektTaiibDbContext>().UseInMemoryDatabase("Testowa").Options;
            var TaiibProjektContext = new ProjektTaiibDbContext(options);
            EventRepository eventRepository = new EventRepository(TaiibProjektContext);

            eventRepository.AddEvent(new ProjektTaiib.DAL.Encje.Event { Id_event = 5, Event_name = "Test", Date = new DateTime(2023, 11, 21, 18, 30, 00), Location = "Test, Test", Category = "Test" });
            eventRepository.Save();

            eventRepository.DeleteEventById(5);
            eventRepository.Save();
            Assert.Null(eventRepository.GetEventById(5));

        }
    }
}
