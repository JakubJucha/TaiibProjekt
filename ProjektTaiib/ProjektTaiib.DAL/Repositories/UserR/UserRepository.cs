using Microsoft.EntityFrameworkCore;
using ProjektTaiib.DAL.Encje;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektTaiib.DAL.Repositories.UserR
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
#pragma warning disable CS8600 // Konwertowanie literału null lub możliwej wartości null na nienullowalny typ.
            User user = context.Users.FirstOrDefault(a => a.Id_user == id);
#pragma warning restore CS8600 // Konwertowanie literału null lub możliwej wartości null na nienullowalny typ.
#pragma warning disable CS8604 // Możliwy argument odwołania o wartości null.
            context.Users.Remove(user);
#pragma warning restore CS8604 // Możliwy argument odwołania o wartości null.
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
#pragma warning disable CS8603 // Możliwe zwrócenie odwołania o wartości null.
            return context.Users.FirstOrDefault(a => a.Id_user == id);
#pragma warning restore CS8603 // Możliwe zwrócenie odwołania o wartości null.
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
