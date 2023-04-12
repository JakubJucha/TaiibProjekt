
using ProjektTaiibWeb_BLL_.Models.ProjektTaiibWeb_BLL_.Models;

namespace ProjektTaiibWeb_BLL_.Models
{
    public class EventDTO
    {
        public int Id_event { get; set; }
        public string Event_name { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public List<TicketDTO> Tickets { get; set; }
        public List<SponsorDTO> Sponsors { get; set; }
    }
}
