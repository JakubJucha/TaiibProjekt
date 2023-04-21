using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjektTaiib.DAL.Encje;
using ProjektTaiib.DAL.Repositories.UserR;
namespace TestDAL
{
    internal class UserRepoDummy : IUserRepository
    {
        public void AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(User user)
        {
            throw new NotImplementedException();
        }

        public void DeleteUserById(int id)
        {
            throw new NotImplementedException();
        }

        public bool ExistUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User?> FindAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<User?> FirstOrDefaultAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }

        public User GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
