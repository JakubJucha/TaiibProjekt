using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProjektTaiib.DAL.Repositories.DetailedInformationR;
using ProjektTaiib.DAL.Repositories.EventR;
using ProjektTaiib.DAL.Repositories.SponsorR;
using ProjektTaiib.DAL.Repositories.TicketR;
using ProjektTaiib.DAL.Repositories.UserR;
using ProjektTaiib.DAL;
using ProjektTaiibWeb.DTO;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ProjektTaiib.DAL.Encje;

namespace ProjektTaiibWeb.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizeController : Controller
    {
        private readonly ProjektTaiibDbContext _context;
        private readonly UnitOfWork unitOfWork;
        private readonly IUserRepository userRepository;
        private readonly IDetailedInformationRepository detailedInformationRepository;
        private readonly IEventRepository eventRepository;
        private readonly ITicketRepository ticketRepository;
        private readonly ISponsorRepository sponsorRepository;
        private readonly IUserRepository _userRepository;
        private readonly IDetailedInformationRepository _detailedInformationRepository;
        public AuthorizeController(IUserRepository userRepository,IDetailedInformationRepository detailedInformationRepository, ProjektTaiibDbContext context)
        {
            _detailedInformationRepository = detailedInformationRepository;
            _userRepository = userRepository;
            _context = context;
            unitOfWork = new UnitOfWork(_context, userRepository, _detailedInformationRepository, eventRepository, ticketRepository, sponsorRepository);
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {

            try
            {
                var user = _userRepository.GetUserByUsername(request.Username);

                if (user == null || user.Password != request.Password)
                {
                    throw new InvalidOperationException("Nieprawidłowa nazwa użytkownika lub hasło.");
                }

                var klucz = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superTajneHasłosuperTajneHasłosuperTajneHasło"));
                var podpisCyfrowy = new SigningCredentials(klucz, SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Role, user.Moderator ? "admin" : "user")
        };
                var parametryTokena = new JwtSecurityToken(
                    issuer: "http://localhost:5168",
                    audience: "http://localhost:4200",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(10),
                    signingCredentials: podpisCyfrowy
                );

                var token = new JwtSecurityTokenHandler().WriteToken(parametryTokena);

                return Ok(new LoginResponse(token));
            }
            catch (InvalidOperationException ex)
            {
                return Unauthorized(ex.Message);
            }
        }
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterRequest request)
        {
            try
            {
                // Sprawdź, czy użytkownik o podanej nazwie użytkownika już istnieje
                var existingUser = _userRepository.GetUserByUsername(request.LoginRegister);
                if (existingUser != null)
                {
                    return BadRequest("Użytkownik o tej nazwie już istnieje.");
                }

                // Możesz dodać tutaj inne sprawdzanie i walidację danych rejestracyjnych

                // Tworzenie nowego użytkownika na podstawie danych z requesta
                var newUser = new User
                {
                    Username = request.LoginRegister,
                    Email = request.Email,
                    Password = request.PasswordRegister,
                    Moderator = false // Ustawienie moderatora w zależności od potrzeb
                                      // Dodaj inne pola w zależności od potrzeb
                };
                var newDetailedInfo = new DetailedInformation
                {
                    UserId = newUser.Id_user,
                    User = newUser,
                    Name = request.Name,
                    Surname = request.Surname,
                    Phone = request.PhoneNumber,
                    Payment = request.Payment,
                    Country = request.Country,
                    City = request.City,
                    Zip_code = request.ZIPCode,
                    Street = request.Street,
                    House_number = request.HouseNumber,
                    Local_number = request.LocalNumber,
                    Additional_information = request.AdditionalInformation


                };
                // Dodanie nowego użytkownika do bazy danych
                _userRepository.AddUser(newUser);
                unitOfWork.SaveChanges();
                _detailedInformationRepository.AddInformation(newDetailedInfo);
                unitOfWork.SaveChanges();

                // Możesz tutaj również generować token JWT i zwracać go w odpowiedzi,
                // podobnie jak w metodzie Login

                return Ok(new RegisterResponse("Rejestracja udana. Możesz teraz się zalogować."));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Wystąpił błąd: {ex.Message}");
            }
        
        }
    }
}
