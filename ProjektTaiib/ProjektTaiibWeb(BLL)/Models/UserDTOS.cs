using ProjektTaiibWeb_BLL_.Models.ProjektTaiibWeb_BLL_.Models;

namespace ProjektTaiibWeb_BLL_.Models
{
    public class UserDTO
    {
        public int IdUser { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Moderator { get; set; }
        public virtual ICollection<TicketDTO> TicketsDTOs { get; set; }
    }
}
