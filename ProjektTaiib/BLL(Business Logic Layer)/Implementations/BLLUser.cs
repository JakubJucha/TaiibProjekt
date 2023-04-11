﻿using BLL_Business_Logic_Layer_.Interfaces;
using ProjektTaiib.DAL.Encje;
using ProjektTaiib.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Business_Logic_Layer_.Implementations
{
    public class BLLUser : IUser
    {
        private UnitOfWork unitOfWork;

        public BLLUser(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
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

        public User GetUserById(int id)
        {
            if (id <= default(int))
                throw new InvalidOperationException("Podane id nie jest poprawne");

            return unitOfWork.UserRepository.GetUserById(id);
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
