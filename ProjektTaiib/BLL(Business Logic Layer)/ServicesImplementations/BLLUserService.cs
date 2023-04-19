using BLL_Business_Logic_Layer_.Services;
using ProjektTaiib.DAL;
using ProjektTaiib.DAL.Encje;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Business_Logic_Layer_.ServicesImplementations
{
    public class BLLUserService : IUserService
    {
        private UnitOfWork unitOfWork;

        public BLLUserService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void AddRandomUsers(int count)
        {
            Random random = new Random();
            for(int j = 0; j < count; j++)
            {
                User u = new User();
                this.unitOfWork.UserRepository.AddUser(u);
            }
            //this.unitOfWork.SaveChanges();
        }

        public void AddUser(User user)
        {
            if (user != null)
            {
                unitOfWork.UserRepository.AddUser(user);
            }
            else
            {
                throw new InvalidOperationException("Error");
            }
        }

        public void DeleteUser(User user)
        {
            if (user != null)
            {
                unitOfWork.UserRepository.DeleteUser(user);
            }
            else
            {
                throw new InvalidOperationException("Error");
            }
        }

        public void DeleteUserById(int id)
        {
            if (id <= default(int))
                throw new InvalidOperationException("Podane id nie jest poprawne");

            unitOfWork.UserRepository.DeleteUserById(id);
        }

        public bool ExistUser(int id)
        {
            if (id <= default(int))
                throw new InvalidOperationException("Podane id nie jest poprawne");

            return unitOfWork.UserRepository.ExistUser(id);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return unitOfWork.UserRepository.GetAllUsers(); 
        }

        public User GetTheRichestUser()
        {
            double money = 0;
            double maxMoney = 0;
            int theRichestOne = 0;
            foreach(User u in GetAllUsers())
            {
               money = GetUsersSpentMoney(u.Id_user);
                if (money > maxMoney)
                {
                    maxMoney = money;
                    theRichestOne = u.Id_user;
                }
            }

            return unitOfWork.UserRepository.GetUserById(theRichestOne);
        }

        public User GetUserById(int id)
        {
            if (id <= default(int))
                throw new InvalidOperationException("Podane id nie jest poprawne");

            return unitOfWork.UserRepository.GetUserById(id);
        }

        public double GetUsersSpentMoney(int id)
        {
            double sum = 0;
            
                foreach (Ticket i in unitOfWork.UserRepository.GetUserById(id).Tickets)
                {
                    sum += i.Price;
                }
            
            return sum;
        }

        public IEnumerable<Ticket> GetUsersTickets(int userId)
        {
            return this.unitOfWork.UserRepository.GetUserById(userId).Tickets;
        }

        public void UpdateUser(User user)
        {
            if (user != null)
            {
                unitOfWork.UserRepository.UpdateUser(user);
            }
            else
            {
                throw new InvalidOperationException("Error");
            }
        }
    }
}
