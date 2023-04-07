using Microsoft.EntityFrameworkCore;
using ProjektTaiib.DAL.Encje;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektTaiib.DAL.Repositories
{
    public class SponsorRepository : ISponsorRepository
    {

        private ProjektTaiibDbContext context;

        public SponsorRepository(ProjektTaiibDbContext context)
        {
            this.context = context;
        }
    
        public void AddSponsor(Sponsor sponsor)
        {
            context.Sponsors.Add(sponsor);
        }

        public void DeleteSponsor(Sponsor sponsor)
        {
            context.Sponsors.Remove(sponsor);
        }

        public void DeleteSponsorById(int id)
        {
            Sponsor sponsor = context.Sponsors.FirstOrDefault(a => a.Id_sponsor == id);
            context.Sponsors.Remove(sponsor);
        }

        public bool ExistSponsor(int id)
        {
            return context.Sponsors.Any(a => a.Id_sponsor == id);
        }

        public IEnumerable<Sponsor> GetAllSponsors()
        {
            return context.Sponsors.ToList();
        }

        public Sponsor GetSponsorById(int id)
        {
            return context.Sponsors.FirstOrDefault(a => a.Id_sponsor == id);
        }

        public void UpdateSponsor(Sponsor sponsor)
        {
            context.Sponsors.Update(sponsor);
        }

        public async Task<Sponsor?> FindAsync(int? id)
        {
            return await context.Sponsors.FindAsync(id);
        }

        public async Task<Sponsor?> FirstOrDefaultAsync(int? id)
        {
            return await context.Sponsors.FirstOrDefaultAsync(a => a.Id_sponsor == id);
        }

        public async Task<IEnumerable<Sponsor>> GetAllSponsorsAsync()
        {
            return await context.Sponsors.ToListAsync();
        }
    }
}
