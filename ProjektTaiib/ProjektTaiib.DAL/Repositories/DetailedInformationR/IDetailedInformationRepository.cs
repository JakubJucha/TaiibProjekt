using ProjektTaiib.DAL.Encje;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektTaiib.DAL.Repositories.DetailedInformationR
{
    public interface IDetailedInformationRepository
    {
        DetailedInformation GetInformationById(int id);
        IEnumerable<DetailedInformation> GetAllInformation();
        void AddInformation(DetailedInformation detailedInformation);
        void UpdateInformation(DetailedInformation detailedInformation);
        void DeleteInformation(DetailedInformation detailedInformation);
        void DeleteInformationById(int id);
        bool ExistInformation(int id);

        Task<IEnumerable<DetailedInformation>> GetAllInformationAsync();
        Task<DetailedInformation?> FirstOrDefaultAsync(int? id);
        Task<DetailedInformation?> FindAsync(int? id);

        public void Save();
    }
}
