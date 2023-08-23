using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NuGet.Protocol.Plugins;
using ProjektTaiib.DAL;
using ProjektTaiib.DAL.Encje;
using ProjektTaiib.DAL.Repositories.DetailedInformationR;
using ProjektTaiib.DAL.Repositories.EventR;
using ProjektTaiib.DAL.Repositories.SponsorR;
using ProjektTaiib.DAL.Repositories.TicketR;
using ProjektTaiib.DAL.Repositories.UserR;
using ProjektTaiibWeb.DTO;

namespace ProjektTaiibWeb.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/user")] 
    public class UserController : Controller
    {
        private readonly ProjektTaiibDbContext _context;
        private readonly UnitOfWork unitOfWork;
        private readonly IUserRepository userRepository;
        private readonly IDetailedInformationRepository _detailedInformationRepository;
        private readonly IEventRepository eventRepository;
        private readonly ITicketRepository ticketRepository;
        private readonly ISponsorRepository sponsorRepository;



        [AllowAnonymous]
        private string GenerateJwtToken(User user)
        {
            var claims = new List<Claim>
    {
        new Claim(JwtRegisteredClaimNames.Sub, user.Username),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
       
    };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superTajneHasłosuperTajneHasłosuperTajneHasło")); 
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(1); 

            var token = new JwtSecurityToken(
               "http://localhost:5168", 
               "http://localhost:4200", 
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository,IDetailedInformationRepository detailedInformationRepository, ProjektTaiibDbContext context)
        {
            _detailedInformationRepository = detailedInformationRepository;
            _userRepository = userRepository;
            _context = context;
            unitOfWork = new UnitOfWork(_context, userRepository, _detailedInformationRepository, eventRepository, ticketRepository, sponsorRepository);
        }

        // GET: User
        public async Task<IActionResult> Index()
        {
            return unitOfWork.UserRepository!= null ?
            View(await unitOfWork.UserRepository.GetAllUsersAsync()) :
                          Problem("Entity set 'ProjektTaiibDbContext.Users'  is null.");
        }

        // GET: User/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || unitOfWork.UserRepository== null)
            {
                return NotFound();
            }

            var user = await unitOfWork.UserRepository
                .FirstOrDefaultAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: User/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_user,Username,Email,Password,Moderator")] User user)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.UserRepository.AddUser(user);
                await unitOfWork.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            
            //var existingUser = unitOfWork.UserRepository.GetUserByUsername(user.Username);
            //if (existingUser != null)
            //{
            //    return BadRequest("Użytkownik o podanej nazwie już istnieje.");
            //}

           
            unitOfWork.UserRepository.AddUser(user);
            unitOfWork.SaveChanges();

            return Ok("Rejestracja zakończona pomyślnie.");
        }


        [AllowAnonymous]
        [HttpGet("detailed-information/{username}")]
        public IActionResult GetUserWithDetailedInfo(string username)
        {
            try
            {
                var user = _userRepository.GetUserByUsername(username);

                if (user == null)
                {
                    return NotFound("Użytkownik nie znaleziony.");
                }

                var detailedInfo = _detailedInformationRepository
                    .GetInformationById(_detailedInformationRepository.getInformationIdByUserId(user.Id_user));

                if (detailedInfo == null)
                {
                    return NotFound("Brak informacji szczegółowych dla użytkownika.");
                }

                var response = new
                {
                    UserId = user.Id_user,
                    Username = user.Username,
                    Email = user.Email,
                    Login = user.Username,
                    
                    Name = detailedInfo.Name,
                    Surname = detailedInfo.Surname,
                    LocalNumber = detailedInfo.Local_number,
                    HouseNumber = detailedInfo.House_number,
                    Phone = detailedInfo.Phone,
                    Street = detailedInfo.Street,
                    Country = detailedInfo.Country,
                    ZIPCode = detailedInfo.Zip_code,
                    City = detailedInfo.City,
                    Payment = detailedInfo.Payment,
                    AdditionalInformation = detailedInfo.Additional_information
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Wystąpił błąd: {ex.Message}");
            }
        }

       

        // POST: User/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_user,Username,Email,Password,Moderator")] User user)
        {
            if (id != user.Id_user)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    unitOfWork.UserRepository.UpdateUser(user);
                    await unitOfWork.SaveAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id_user))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: User/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || unitOfWork.UserRepository== null)
            {
                return NotFound();
            }

            var user = await unitOfWork.UserRepository
                .FirstOrDefaultAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (unitOfWork.UserRepository== null)
            {
                return Problem("Entity set 'ProjektTaiibDbContext.Users'  is null.");
            }
            var user = await unitOfWork.UserRepository.FindAsync(id);
            if (user != null)
            {
                unitOfWork.UserRepository.DeleteUser(user);
            }
            
            await unitOfWork.SaveAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
          return (unitOfWork.UserRepository?.ExistUser(id)).GetValueOrDefault();
        }
    }
}
