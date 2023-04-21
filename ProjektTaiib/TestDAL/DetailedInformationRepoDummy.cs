using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjektTaiib.DAL.Encje;
using ProjektTaiib.DAL.Repositories.DetailedInformationR;
namespace TestDAL
{
    internal class DetailedInformationRepoDummy : IDetailedInformationRepository
    {
        public DetailedInformationRepoDummy()
        {
        }

        public void AddInformation(DetailedInformation detailedInformation)
        {
            throw new NotImplementedException();
        }

        public void DeleteInformation(DetailedInformation detailedInformation)
        {
            throw new NotImplementedException();
        }

        public void DeleteInformationById(int id)
        {
            throw new NotImplementedException();
        }

        public bool ExistInformation(int id)
        {
            throw new NotImplementedException();
        }

        public Task<DetailedInformation?> FindAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<DetailedInformation?> FirstOrDefaultAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DetailedInformation> GetAllInformation()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DetailedInformation>> GetAllInformationAsync()
        {
            throw new NotImplementedException();
        }

        public DetailedInformation GetInformationById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void UpdateInformation(DetailedInformation detailedInformation)
        {
            throw new NotImplementedException();
        }
    }
}
