using Microsoft.EntityFrameworkCore;
using ProjektTaiib.DAL.Repositories.EventR;
using ProjektTaiib.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjektTaiib.DAL.Repositories.DetailedInformationR;
using ProjektTaiib.DAL.Encje;

namespace TestDAL.UnitOfTest
{
    public class UnitOfTestDetailedInformationRepo
    {
        [Fact]
        public void TestAddInformation()
        {
            var options = new DbContextOptionsBuilder<ProjektTaiibDbContext>().UseInMemoryDatabase("Testowa").Options;
            var TaiibProjektContext = new ProjektTaiibDbContext(options);
            DetailedInformationRepository detailedInformationRepository = new DetailedInformationRepository(TaiibProjektContext);

            detailedInformationRepository.AddInformation(new DetailedInformation { Id_information = 1, UserId = 1, Name = "Test", Surname = "Test", Email = "Test@test.com", Phone = "123123123", Payment = "Blik", Country = "Poland", City = "Katowice", Zip_code = "40-000", Street = "Francuska", House_number = 24, Local_number = 7 });
            detailedInformationRepository.Save();
            Assert.Equal(1,detailedInformationRepository.GetAllInformation().Count());


        }


        [Fact]
        public void TestDeleteEventById()
        {
            var options = new DbContextOptionsBuilder<ProjektTaiibDbContext>().UseInMemoryDatabase("Testowa").Options;
            var TaiibProjektContext = new ProjektTaiibDbContext(options);
            DetailedInformationRepository detailedInformationRepository = new DetailedInformationRepository(TaiibProjektContext);

            detailedInformationRepository.AddInformation(new DetailedInformation { Id_information = 5, UserId = 1, Name = "Test", Surname = "Test", Email = "Test@test.com", Phone = "123123123", Payment = "Blik", Country = "Poland", City = "Katowice", Zip_code = "40-000", Street = "Francuska", House_number = 24, Local_number = 7 });
            detailedInformationRepository.Save();

            detailedInformationRepository.DeleteInformationById(5);
            detailedInformationRepository.Save();
            Assert.Null(detailedInformationRepository.GetInformationById(5));

        }
    }
}
