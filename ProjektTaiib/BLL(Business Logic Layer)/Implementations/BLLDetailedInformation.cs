﻿using ProjektTaiib.DAL.Encje;
using ProjektTaiib.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Business_Logic_Layer_.Implementations
{
    public class BLLDetailedInformation
    {
        private UnitOfWork unitOfWork;

        public BLLDetailedInformation(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public void AddInformation(DetailedInformation detailedInformation)
        {
            if (detailedInformation != null)
            {
                unitOfWork.DetailedInformationRepository.AddInformation(detailedInformation);
            }
            else
            {
                throw new InvalidOperationException("Error");
            }
        }

        public void DeleteInformation(DetailedInformation detailedInformation)
        {
            if (detailedInformation != null)
            {
                unitOfWork.DetailedInformationRepository.DeleteInformation(detailedInformation);
            }
            else
            {
                throw new InvalidOperationException("Error");
            }
        }

        public void DeleteInformationById(int id)
        {
            if (id <= default(int))
                throw new InvalidOperationException("Podane id nie jest poprawne");

            unitOfWork.DetailedInformationRepository.DeleteInformationById(id);

        }

        public bool ExistInformation(int id)
        {
            if (id <= default(int))
                throw new InvalidOperationException("Podane id nie jest poprawne");

            bool exists = unitOfWork.DetailedInformationRepository.ExistInformation(id);
            return exists;
        }

        public IEnumerable<DetailedInformation> GetAllInformation()
        {
            return unitOfWork.DetailedInformationRepository.GetAllInformation();
        }

        public DetailedInformation GetInformationById(int id)
        {
            if (id <= default(int))
                throw new InvalidOperationException("Podane id nie jest poprawne");

            return unitOfWork.DetailedInformationRepository.GetInformationById(id);
        }

        public void UpdateInformation(DetailedInformation detailedInformation)
        {
            if (detailedInformation != null)
            {
                unitOfWork.DetailedInformationRepository.UpdateInformation(detailedInformation);
            }
            else
            {
                throw new InvalidOperationException("Error");
            }
        }
    }
}