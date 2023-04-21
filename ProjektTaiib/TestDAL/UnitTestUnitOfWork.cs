using ProjektTaiib.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDAL
{
    
    public class UnitTestUnitOfWork
    {
        [Fact]
        public void TestUnitOfWork()
        {
            var userRepo = new UserRepoDummy();
            var detailedInformationRepo = new DetailedInformationRepoDummy();
            var eventRepo = new EventRepoDummy();
            var sponsorRepo = new SponsorRepoDummy();
            var ticketRepo = new TicketRepoDummy();

            var unitOfWorkU = new UnitOfWork(userRepo);
            var unitOfWorkD = new UnitOfWork(detailedInformationRepo);
            var unitOfWorkE = new UnitOfWork(eventRepo);
            var unitOfWorkS = new UnitOfWork(sponsorRepo);
            var unitOfWorkT = new UnitOfWork(ticketRepo);

            Assert.Same(userRepo, unitOfWorkU.UserRepository);
        }
    }
}
