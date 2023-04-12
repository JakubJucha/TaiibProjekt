namespace ProjektTaiibWeb_BLL_.Models
{
    namespace ProjektTaiibWeb_BLL_.Models
    {
        public class TicketDTO
        {
            public int Id_ticket { get; set; }
            public int Id_event { get; set; }
            public EventDTO Event { get; set; }
            public string Type { get; set; }
            public double Price { get; set; }
            public bool? Premium { get; set; }
        }
    }
}
