using BLL_Business_Logic_Layer_.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjektTaiib.DAL.Encje;

namespace ProjektTaiibWeb_BLL_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetailedInformationControllerAPI : ControllerBase
    {
        private readonly IDetailedInformationService _detailedInformationService;

        public DetailedInformationControllerAPI(IDetailedInformationService detailedInformationService)
        {
            this._detailedInformationService = detailedInformationService;
        }

        [HttpGet("payment")]
        public IEnumerable<DetailedInformation> InformacjePoPlatnosci(string payment)
        {
            return _detailedInformationService.GetInformationByPayment(payment);
        }

        [HttpGet("names")]
        public IEnumerable<DetailedInformation> InformacjePoNazwiskuAlfabetycznie()
        {
            return _detailedInformationService.GetInformationByAlphabeticalSurnames();
        }

        [HttpGet("payment_async")]
        public async Task<IEnumerable<DetailedInformation>> InformacjePoPlatnosciAsync(string payment)
        {
            DetailedInformation[]? info = null;
            await Task.Factory.StartNew(() => { info = (DetailedInformation[]?)_detailedInformationService.GetInformationByPayment(payment); });
            return info;
        }

    }
}
