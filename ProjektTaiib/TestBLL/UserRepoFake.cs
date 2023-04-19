using ProjektTaiib.DAL.Encje;
using ProjektTaiib.DAL.Repositories.UserR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBLL
{
    internal class UserRepoFake : IUserRepository
    {

        private List<User> users = new List<User>();
        public void AddUser(User user)
        {
            this.users.Add(user);
        }

        public void DeleteUser(User user)
        {
            if(user != null)
            this.users.Remove(user);
        }

        public void DeleteUserById(int id)
        {
            var user = this.users.Find(u => u.Id_user == id);
            if(user != null) this.users.Remove(user);
        }

        public bool ExistUser(int id)
        {
            return this.users.Any(u => u.Id_user == id);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return this.users;
        }
 
        public User GetUserById(int id)
        {
            var user = this.users.Find(u => u.Id_user == id);
            return user;
        }

        public void UpdateUser(User user)
        {
            int index = this.users.FindIndex(u => u.Id_user == user.Id_user);
            if(index != -1) this.users[index] = user;
        }

        //-------------------Asynchroniczne

        public Task<IEnumerable<User>> GetAllUsersAsync()
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
    }
}
