using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjektTaiib.DAL.Encje;
using ProjektTaiib.DAL.Repositories.SponsorR;
namespace TestDAL
{
    internal class SponsorRepoDummy : ISponsorRepository
    {
        public void AddSponsor(Sponsor sponsor)
        {
            throw new NotImplementedException();
        }

        public void DeleteSponsor(Sponsor sponsor)
        {
            throw new NotImplementedException();
        }

        public void DeleteSponsorById(int id)
        {
            throw new NotImplementedException();
        }

        public bool ExistSponsor(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Sponsor?> FindAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<Sponsor?> FirstOrDefaultAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Sponsor> GetAllSponsors()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Sponsor>> GetAllSponsorsAsync()
        {
            throw new NotImplementedException();
        }

        public Sponsor GetSponsorById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void UpdateSponsor(Sponsor sponsor)
        {
            throw new NotImplementedException();
        }
    }
}
