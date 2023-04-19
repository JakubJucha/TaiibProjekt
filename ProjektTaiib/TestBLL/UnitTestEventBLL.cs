using BLL_Business_Logic_Layer_.ServicesImplementations;
using Moq;
using ProjektTaiib.DAL;
using ProjektTaiib.DAL.Encje;
using ProjektTaiib.DAL.Repositories.EventR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBLL
{
    public class UnitTestEventBLL
    {

        [Fact]
        public void GetEventsByCategoryTest()
        {
            var eventRepo = new EventRepoFake();
            var unitOfWork = new UnitOfWork(eventRepo);
            var eventsBLL = new BLLEventService(unitOfWork);

            Event event1 = new Event();
            Event event2 = new Event();
            Event event3 = new Event();
            event1.Category = "Concert";
            event3.Category = "Concert";
            event2.Category = "Match";

            eventRepo.AddEvent(event1);
            eventRepo.AddEvent(event2);
            eventRepo.AddEvent(event3);

            Assert.Equal(2, eventsBLL.GetEventsByCategory("Concert").Count());

        }

        [Fact]
        public void GetEventsByDateTest()
        {
            var eventRepo = new EventRepoFake();
            var unitOfWork = new UnitOfWork(eventRepo);
            var eventsBLL = new BLLEventService(unitOfWork);

            Event event1 = new Event();
            Event event2 = new Event();
            Event event3 = new Event();

            event1.Date = new DateTime(2023, 4, 19);
            event2.Date = new DateTime(2022, 11, 11);
            event3.Date = new DateTime(2022, 11, 11);

            eventRepo.AddEvent(event1);
            eventRepo.AddEvent(event2);
            eventRepo.AddEvent(event3);

            Assert.Equal(2, eventsBLL.GetEventsByDate(new DateTime(2022, 11, 11)).Count());
        }

        //Moq
        [Fact]
        public void GetEventsByCategoryTestMoq()
        {
            Mock<IEventRepository> mockEventRepo = new Mock<IEventRepository>();

            Event event1 = new Event();
            Event event2 = new Event();
            Event event3 = new Event();
            event1.Category = "Concert";
            event3.Category = "Concert";
            event2.Category = "Match";

            mockEventRepo.Setup(x => x.GetEvents()).Returns(new List<Event> {event1,event2,event3 });

            var unitOfWork = new UnitOfWork(mockEventRepo.Object);
            var eventsBLL = new BLLEventService(unitOfWork);

            Assert.Equal(2, eventsBLL.GetEventsByCategory("Concert").Count());
        }

        [Fact]
        public void GetEventsByDateTestMoq()
        {
            Mock<IEventRepository> mockEventRepo = new Mock<IEventRepository>();

            Event event1 = new Event();
            Event event2 = new Event();
            Event event3 = new Event();
            event1.Date = new DateTime(2023, 4, 19);
            event2.Date = new DateTime(2022, 11, 11);
            event3.Date = new DateTime(2022, 11, 11);

            mockEventRepo.Setup(x => x.GetEvents()).Returns(new List<Event> { event1, event2, event3 });


            var unitOfWork = new UnitOfWork(mockEventRepo.Object);
            var eventsBLL = new BLLEventService(unitOfWork);

            Assert.Equal(2, eventsBLL.GetEventsByDate(new DateTime(2022,11,11)).Count());
        }

    }
}
