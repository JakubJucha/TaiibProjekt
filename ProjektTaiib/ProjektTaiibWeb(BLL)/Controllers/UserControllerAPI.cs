using BLL_Business_Logic_Layer_.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjektTaiib.DAL.Encje;

namespace ProjektTaiibWeb_BLL_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserControllerAPI : ControllerBase
    {
        private readonly IUserService _userService;

        public UserControllerAPI(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpGet("richest")]
        public User? NajbogatszyUzytkownik()
        {
            return _userService.GetTheRichestUser();
        }

        [HttpGet("spentMoney")]
        public double WydanePieniadzeUzytkownika(int id)
        {
            return _userService.GetUsersSpentMoney(id);
        }

        [HttpGet("richest_async")]
        public async Task<User?> NajbogatszyUzytkownikAsync()
        {
            User? richest = null;
            await Task.Factory.StartNew(() => { richest = _userService.GetTheRichestUser(); });
            return richest;
        }
    }
}
