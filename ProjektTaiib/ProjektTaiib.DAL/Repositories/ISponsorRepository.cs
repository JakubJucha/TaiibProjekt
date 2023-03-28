using ProjektTaiib.DAL.Encje;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektTaiib.DAL.Repositories
{
    public interface ISponsorRepository
    {
        Sponsor GetSponsorById(int id);
        IEnumerable<Sponsor> GetAllSponsors();
        void AddSponsor(Sponsor sponsor);
        void UpdateSponsor(Sponsor sponsor);
        void DeleteSponsor(Sponsor sponsor);
    }
}
