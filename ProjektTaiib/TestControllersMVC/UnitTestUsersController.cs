using BLL_Business_Logic_Layer_.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjektTaiibWeb_BLL_;
using ProjektTaiibWeb.Controllers;
using ProjektTaiibWeb_BLL_.Controllers;
using Moq;
using ProjektTaiib.DAL;
using ProjektTaiib.DAL.Encje;

namespace TestControllersMVC
{
    public class UnitTestUsersController
    {
        [Fact]
        public void TestNajbogatszyUzytkownik()
        {
            Mock<IUserService> mockUsersBLL = new Mock<IUserService>();

            var najbogatszy = new User();


            mockUsersBLL
                .Setup(u => u.GetTheRichestUser())
                .Returns(najbogatszy);


            UserControllerBLL userController = new UserControllerBLL(mockUsersBLL.Object);


            var result = userController.NajbogatszyUzytkownik();

            Assert.IsType<ViewResult>(result);

            var viewResult = (ViewResult)result;
            Assert.Same(viewResult.Model, najbogatszy);
        }
        [Fact]
        public void TestDodajLosowoAction()
        {
            UsersBLLMock usersBLLMock = new UsersBLLMock();
            UserControllerBLL userControllerBLL = new UserControllerBLL(usersBLLMock);
            var result = userControllerBLL.DodajLosowo(4);

            Assert.IsType<ViewResult>(result);

            var viewResult = (ViewResult)result;
            Assert.Null(viewResult.Model);
            Assert.Equal(4, usersBLLMock.IluDodano);
        }
        [Fact]
        public void TestDodajLosowoActionMoq()
        {
            Mock<IUserService> usersBLLMock = new Mock<IUserService>();


            UserControllerBLL userControllerBLL = new UserControllerBLL(usersBLLMock.Object);
            var result = userControllerBLL.DodajLosowo(4);

            Assert.IsType<ViewResult>(result);

            var viewResult = (ViewResult)result;
            Assert.Null(viewResult.Model);

            usersBLLMock.Verify(s => s.AddRandomUsers(4));
        }
    }
}
