using BLL_Business_Logic_Layer_.ServicesImplementations;
using Moq;
using ProjektTaiib.DAL;
using ProjektTaiib.DAL.Encje;
using ProjektTaiib.DAL.Repositories.UserR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBLL
{
    public class UnitTestUsersBLL
    {
        [Fact]
        public void TestAddRandomUsers()
        {
            var userRepo = new UserRepoFake();
            var unitOfWork = new UnitOfWork(userRepo);
            var usersBLL = new BLLUserService(unitOfWork);

            usersBLL.AddRandomUsers(5);
            Assert.Equal(5, userRepo.GetAllUsers().Count());
        }

        [Fact]

        public void GetUsersSpentMoneyTest()
        {
            var userRepo = new UserRepoFake();
            var unitOfWork = new UnitOfWork(userRepo);
            var usersBLL = new BLLUserService(unitOfWork);

            List<Ticket> tickets = new List<Ticket>();
            Ticket ticket = new Ticket();
            Ticket ticket2 = new Ticket();
            ticket2.Price = 100;
            ticket.Price = 20.99;
            tickets.Add(ticket);
            tickets.Add(ticket2);

            User user = new User();
            user.Tickets = tickets;
            userRepo.AddUser(user);

            Assert.Equal(120.99, usersBLL.GetUsersSpentMoney(user.Id_user));

        }

        //MOQ

        [Fact]
        public void TestAddRandomUsersMoq()
        {
            Mock<IUserRepository> mockUserRepo = new Mock<IUserRepository>();
            var unitOfWork = new UnitOfWork(mockUserRepo.Object);
            var usersBLL = new BLLUserService(unitOfWork);
            
            usersBLL.AddRandomUsers(5);
        }

        [Fact]
        public void GetUsersSpentMoneyTestMoq()
        {
            Mock<IUserRepository> mockUserRepo = new Mock<IUserRepository>();
            
            List<Ticket> tickets = new List<Ticket>();
            Ticket ticket = new Ticket();
            ticket.Price = 20.99;
            tickets.Add(ticket);

            User user = new User();
            user.Id_user = 1;
            user.Tickets = tickets;

            mockUserRepo.Setup(x => x.GetUserById(user.Id_user)).Returns(user);

            var unitOfWork = new UnitOfWork(mockUserRepo.Object);
            var usersBLL = new BLLUserService(unitOfWork);

           Assert.Equal(20.99, usersBLL.GetUsersSpentMoney(user.Id_user));
        }

    }
}
