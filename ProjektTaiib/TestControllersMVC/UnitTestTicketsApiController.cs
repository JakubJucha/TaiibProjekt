using BLL_Business_Logic_Layer_.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ProjektTaiib.DAL.Encje;
using ProjektTaiibWeb_BLL_.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestControllersMVC
{
    public class UnitTestTicketsApiController
    {
        [Fact]
        public void TestIloscBiletowDlaEventuAction()
        {
            Mock<ITicketService> mockTicketApi = new Mock<ITicketService>();

            Event e = new Event();
            e.Id_event = 999;

            Ticket t1 = new Ticket();
            Ticket t2 = new Ticket();

            t1.Event = e; t1.Id_event = 999;
            t2.Event = e; t2.Id_event = 999;


            mockTicketApi
               .Setup(t => t.GetTicketCountOnEvent(999))
               .Returns(2);


            TicketControllerAPI ticketController = new TicketControllerAPI(mockTicketApi.Object);


            var result = ticketController.IloscBiletowDlaEventu(999);

            
            Assert.Equal(2, result);
        }
        [Fact]
        public void TestBiletyNaDanyTypEventuAction()
        {
            Mock<ITicketService> mockTicketApi = new Mock<ITicketService>();
            List<Ticket> tick = new List<Ticket>();
            Event e = new Event();
            e.Id_event = 999;

            Ticket t1 = new Ticket();
            Ticket t2 = new Ticket();

            t1.Type = "test";
            t2.Type = "test";

            tick.Add(t1);
            tick.Add(t2);

            mockTicketApi
             .Setup(ta => ta.GetTicketsByTypeonEvent(999, "test"))
             .Returns(tick);


            TicketControllerAPI ticketController = new TicketControllerAPI(mockTicketApi.Object);


            var result = ticketController.BiletyNaDanyTypEventu(999, "test");

           
            Assert.Equal(tick, result);
        }

     
    }
}
