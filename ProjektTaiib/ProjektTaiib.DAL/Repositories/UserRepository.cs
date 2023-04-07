using Microsoft.EntityFrameworkCore;
using ProjektTaiib.DAL.Encje;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektTaiib.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {

        private ProjektTaiibDbContext context;
        public UserRepository(ProjektTaiibDbContext context)
        {
            this.context = context;
        }

        public void AddUser(User user)
        {
            context.Users.Add(user);
        }

        public void DeleteUser(User user)
        {
            context.Users.Remove(user);
        }

        public void DeleteUserById(int id)
        {
            User user = context.Users.FirstOrDefault(a => a.Id_user == id);
            context.Users.Remove(user);
        }

        public bool ExistUser(int id)
        {
            return context.Users.Any(a => a.Id_user == id);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return context.Users.ToList();
        }

        public User GetUserById(int id)
        {
            return context.Users.FirstOrDefault(a => a.Id_user == id);
        }

        public void UpdateUser(User user)
        {
            context.Users.Update(user);
        }

        public async Task<User?> FindAsync(int? id)
        {
            return await context.Users.FindAsync(id);
        }

        public async Task<User?> FirstOrDefaultAsync(int? id)
        {
            return await context.Users.FirstOrDefaultAsync(a => a.Id_user == id);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await context.Users.ToListAsync();
        }
    }
}
