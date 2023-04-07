using ProjektTaiib.DAL.Encje;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektTaiib.DAL.Repositories
{
    public class DetailedInformationRepository : IDetailedInformationRepository
    {

        private ProjektTaiibDbContext context;

        public DetailedInformationRepository(ProjektTaiibDbContext context)
        {
            this.context = context;
        }

        public void AddInformation(DetailedInformation detailedInformation)
        {
            context.DetailedInformation.Add(detailedInformation);
        }

        public void DeleteInformation(DetailedInformation detailedInformation)
        {
            context.DetailedInformation.Remove(detailedInformation);
        }

        public void DeleteInformationById(int id)
        {
            DetailedInformation detailedInformation = context.DetailedInformation.FirstOrDefault(a => a.Id_information == id);
            context.DetailedInformation.Remove(detailedInformation);
        }

        public bool ExistInformation(int id)
        {
            return context.DetailedInformation.Any(a => a.Id_information == id);
        }

        public IEnumerable<DetailedInformation> GetAllInformation()
        {
            return context.DetailedInformation.ToList();
        }

        public DetailedInformation GetInformationById(int id)
        {
            return context.DetailedInformation.FirstOrDefault(a => a.Id_information == id);
        }

        public void UpdateInformation(DetailedInformation detailedInformation)
        {
            context.DetailedInformation.Update(detailedInformation);
        }
    }
}
