using Microsoft.EntityFrameworkCore;
using ProjektTaiib.DAL.Repositories.EventR;
using ProjektTaiib.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjektTaiib.DAL.Repositories.SponsorR;
using ProjektTaiib.DAL.Encje;

namespace TestDAL.UnitOfTest
{
    public class UnitOfTestSponsorRepo
    {

        [Fact]
        public void TestAddSponsor()
        {
            var options = new DbContextOptionsBuilder<ProjektTaiibDbContext>().UseInMemoryDatabase("Testowa").Options;
            var TaiibProjektContext = new ProjektTaiibDbContext(options);
            SponsorRepository sponsorRepository = new SponsorRepository(TaiibProjektContext);

            sponsorRepository.AddSponsor(new Sponsor { Id_sponsor = 3, Sponsor_name = "Test" });
            sponsorRepository.Save();
            Assert.NotNull(sponsorRepository.GetSponsorById(3));


        }


        [Fact]
        public void TestDeleteEventById()
        {
            var options = new DbContextOptionsBuilder<ProjektTaiibDbContext>().UseInMemoryDatabase("Testowa").Options;
            var TaiibProjektContext = new ProjektTaiibDbContext(options);
            SponsorRepository sponsorRepository = new SponsorRepository(TaiibProjektContext);

            sponsorRepository.AddSponsor(new Sponsor { Id_sponsor = 5, Sponsor_name = "Test" });
            sponsorRepository.Save();

            sponsorRepository.DeleteSponsorById(5);
            sponsorRepository.Save();
            Assert.Null(sponsorRepository.GetSponsorById(5));

        }

    }
}
