using BLL_Business_Logic_Layer_.Services;
using Microsoft.Extensions.Logging;
using ProjektTaiib.DAL;
using ProjektTaiib.DAL.Encje;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Business_Logic_Layer_.ServicesImplementations
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

        public IEnumerable<Event> GetSponsoredEvents(int id)
        {
            return this.unitOfWork.EventRepository.GetEvents().Where(s => s.Sponsors.Contains(GetSponsorById(id)));
        }

        public IEnumerable<Sponsor> GetSponsorsByName(string name)
        {
            return this.unitOfWork.SponsorRepository.GetAllSponsors().Where(n => n.Sponsor_name == name);
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
