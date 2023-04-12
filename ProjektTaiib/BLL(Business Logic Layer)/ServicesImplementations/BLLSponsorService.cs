using BLL_Business_Logic_Layer_.Interfaces;
using Microsoft.Extensions.Logging;
using ProjektTaiib.DAL.Encje;
using ProjektTaiib.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Business_Logic_Layer_.Implementations
{
    public class BLLSponsorService : ISponsorService
    {

        private UnitOfWork unitOfWork;

        public BLLSponsorService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void AddSponsor(Sponsor sponsor)
        {
            if (sponsor != null)
            {
                unitOfWork.SponsorRepository.AddSponsor(sponsor);
            }
            else
            {
                throw new InvalidOperationException("Error");
            }
        }

        public void DeleteSponsor(Sponsor sponsor)
        {
            if (sponsor != null)
            {
                unitOfWork.SponsorRepository.DeleteSponsor(sponsor);
            }
            else
            {
                throw new InvalidOperationException("Error");
            }
        }

        public void DeleteSponsorById(int id)
        {
            if (id <= default(int))
                throw new InvalidOperationException("Podane id nie jest poprawne");

            unitOfWork.SponsorRepository.DeleteSponsorById(id);
        }

        public bool ExistSponsor(int id)
        {
            if (id <= default(int))
                throw new InvalidOperationException("Podane id nie jest poprawne");

            bool ifExists = unitOfWork.SponsorRepository.ExistSponsor(id);
            return ifExists;
        }

        public IEnumerable<Sponsor> GetAllSponsors()
        {
            return unitOfWork.SponsorRepository.GetAllSponsors();
        }

        public Sponsor GetSponsorById(int id)
        {
            if (id <= default(int))
                throw new InvalidOperationException("Podane id nie jest poprawne");

            return unitOfWork.SponsorRepository.GetSponsorById(id);
        }

        public void UpdateSponsor(Sponsor sponsor)
        {
            if (sponsor != null)
            {
                unitOfWork.SponsorRepository.UpdateSponsor(sponsor);
            }
            else
            {
                throw new InvalidOperationException("Error");
            }
        }
    }
}
