using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL_Business_Logic_Layer_.Services;
using ProjektTaiib.DAL.Encje;
using ProjektTaiibWeb_BLL_;

namespace TestControllersMVC
{
    internal class UsersBLLMock : IUserService
    {
        public int IluDodano { get; set; }
        public void AddRandomUsers(int count)
        {
            IluDodano = count;
        }

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

        public IEnumerable<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public User GetTheRichestUser()
        {
            throw new NotImplementedException();
        }

        public User GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public double GetUsersSpentMoney(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ticket> GetUsersTickets(int userId)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
