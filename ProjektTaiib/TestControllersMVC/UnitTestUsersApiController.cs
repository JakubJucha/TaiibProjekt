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
    public class UnitTestUsersApiController
    {
        [Fact]
        public void TestNajbogatszyUzytkownik()
        {
            Mock<IUserService> mockUsersBLL = new Mock<IUserService>();

            var najbogatszy = new User();


            mockUsersBLL
                .Setup(u => u.GetTheRichestUser())
                .Returns(najbogatszy);


            UserControllerAPI userController = new UserControllerAPI(mockUsersBLL.Object);


           
            Assert.Same(userController.NajbogatszyUzytkownik(), najbogatszy);
        }
        [Fact]
        public void TestWydanePieniadzeUzytkownika()
        {
            Mock<IUserService> mockUsersBLL = new Mock<IUserService>();

            User tempUser = new User();
            tempUser.Id_user = 999;
            Ticket ticket = new Ticket();
            ticket.Price = 1200;
            tempUser.Tickets?.Add(ticket);

            mockUsersBLL
                .Setup(u=>u.GetUsersSpentMoney(999))
                .Returns(1200);


            UserControllerAPI userController = new UserControllerAPI(mockUsersBLL.Object);



            Assert.Equal(1200, userController.WydanePieniadzeUzytkownika(999));
        }

        [Fact]
        public void TestNajbogatszyUzytkownikAsync()
        {
            Mock<IUserService> mockUsersBLL = new Mock<IUserService>();

            var najbogatszy = new User();


            mockUsersBLL
                .Setup(u => u.GetTheRichestUser())
                .Returns(najbogatszy);


            UserControllerAPI userController = new UserControllerAPI(mockUsersBLL.Object);



            Assert.Same(userController.NajbogatszyUzytkownikAsync().Result, najbogatszy);
        }

    }
}
