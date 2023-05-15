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

            var unitOfWorkU = new UnitOfWork(null,userRepo,null,null,null,null);
            var unitOfWorkD = new UnitOfWork(null,null,detailedInformationRepo,null,null,null);
            var unitOfWorkE = new UnitOfWork(null,null,null,eventRepo,null,null);
            var unitOfWorkS = new UnitOfWork(null,null,null,null,null,sponsorRepo);
            var unitOfWorkT = new UnitOfWork(null,null,null,null,ticketRepo,null);

            Assert.Same(userRepo, unitOfWorkU.UserRepository);
        }
    }
}
