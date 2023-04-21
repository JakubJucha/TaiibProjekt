using Microsoft.EntityFrameworkCore;
using ProjektTaiib.DAL;
using ProjektTaiib.DAL.Repositories.UserR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TestDAL.UnitOfTest
{
    public class UnitOfTestUserRepo
    {
    

        [Fact]
        public void TestGetAllUsers()
        {
            var options = new DbContextOptionsBuilder<ProjektTaiibDbContext>().UseInMemoryDatabase("Testowa").Options;
            var TaiibProjektContext = new ProjektTaiibDbContext(options);
            UserRepository userRepository = new UserRepository(TaiibProjektContext);

            Assert.Empty(userRepository.GetAllUsers());
            userRepository.AddUser(new ProjektTaiib.DAL.Encje.User { Id_user = 1, Email = "test@test.com", Moderator = false, Username = "Testowy", Password = "Haslo123" });
            userRepository.Save();
            Assert.Equal(1, userRepository.GetAllUsers().Count());


        }


        [Fact]
        public void TestDeleteUserById()
        {
            var options = new DbContextOptionsBuilder<ProjektTaiibDbContext>().UseInMemoryDatabase("Testowa").Options;
            var TaiibProjektContext = new ProjektTaiibDbContext(options);
            UserRepository userRepository = new UserRepository(TaiibProjektContext);

            userRepository.AddUser(new ProjektTaiib.DAL.Encje.User { Id_user = 5, Email = "test@test.com", Moderator = false, Username = "Testowy", Password = "Haslo123" });
            userRepository.Save();

            userRepository.DeleteUserById(5);
            userRepository.Save();
            Assert.Null(userRepository.GetUserById(5));

        }
    }
}
