using ProjektTaiib.DAL.Encje;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektTaiib.DAL.Repositories
{
    public interface IUserRepository
    {
        User GetUserById(int id);

        IEnumerable<User> GetAllUsers();
        void AddUser(User user);
        void DeleteUser(User user);
        void DeleteUserById(int id);
        void UpdateUser(User user);
        bool ExistUser(int id);

        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User?> FirstOrDefaultAsync(int? id);
        Task<User?> FindAsync(int? id);
    }
}
