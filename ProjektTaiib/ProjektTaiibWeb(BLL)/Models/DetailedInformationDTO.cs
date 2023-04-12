namespace ProjektTaiibWeb_BLL_.Models
{
    public class DetailedInformationDTO
    {
        public int Id_information { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Payment { get; set; }
        public string Country { get; set; }
        public UserDTO UserDTO { get; set; }
    }
}
