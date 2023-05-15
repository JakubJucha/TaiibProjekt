using BLL_Business_Logic_Layer_.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ProjektTaiib.DAL.Encje;
using ProjektTaiibWeb.Controllers;
using ProjektTaiibWeb_BLL_.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestControllersMVC
{
    public class UnitTestTicketsController
    {
        [Fact]
        public void TestLiczbaTicketowZEventu()
        {
            Mock<ITicketService> mockTicketBLL = new Mock<ITicketService>();

            Event e = new Event();
            e.Id_event = 999;

            Ticket t1 = new Ticket();
            Ticket t2 = new Ticket();

            t1.Event = e;t1.Id_event = 999;
            t2.Event = e;t2.Id_event = 999;


            mockTicketBLL
               .Setup(t => t.GetTicketCountOnEvent(999))
               .Returns(2);


            TicketControllerBLL ticketController = new TicketControllerBLL(mockTicketBLL.Object);


            var result = ticketController.IloscBiletowDlaEventu(999);

            Assert.IsType<ViewResult>(result);

            var viewResult = (ViewResult)result;
            Assert.Equal(2, viewResult.ViewData["Ilosc"]);
        }

        [Fact]
        public void BiletyPoTypieEventu()
        {

            Mock<ITicketService> mockTicketBLL = new Mock<ITicketService>();
            List<Ticket> tick = new List<Ticket>();
            Event e = new Event();
            e.Id_event = 999;

            Ticket t1 = new Ticket();
            Ticket t2 = new Ticket();

            t1.Type = "test";
            t2.Type = "test";

            tick.Add(t1);
            tick.Add(t2);

            mockTicketBLL
             .Setup(ta => ta.GetTicketsByTypeonEvent(999, "test"))
             .Returns(tick);


            TicketControllerBLL ticketController = new TicketControllerBLL(mockTicketBLL.Object);


            var result = ticketController.BiletyNaDanyTypEventu(999,"test");

            Assert.IsType<ViewResult>(result);

            var viewResult = (ViewResult)result;
            Assert.Equal(tick, viewResult.ViewData["Bilety"]);
        }

    }
}
