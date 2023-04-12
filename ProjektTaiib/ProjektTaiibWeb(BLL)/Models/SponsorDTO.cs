namespace ProjektTaiibWeb_BLL_.Models
{
    public class SponsorDTO
    {
        public int Id_sponsor { get; set; }
        public string Sponsor_name { get; set; }
        public List<EventDTO> Events { get; set; }
    }
}
