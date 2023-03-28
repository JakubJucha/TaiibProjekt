using ProjektTaiib.DAL.Encje;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektTaiib.DAL.Repositories
{
    public interface IDetailedInformationRepository
    {
        DetailedInformation GetInformationById(int id);
        IEnumerable<DetailedInformation> GetAllInformation();
        void AddInformation(DetailedInformation detailedInformation);
        void UpdateInformation(DetailedInformation detailedInformation);
        void DeleteInformation(DetailedInformation detailedInformation);
    }
}
