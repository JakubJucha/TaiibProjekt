namespace ProjektTaiibWeb.DTO
{
    public class EventInformation {

        public string EventName { get; set; }
        public DateTime Datetime { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }     
        public decimal TicketPrice { get; set; }
        public int TicketAmount { get; set; }
        public string Sponsors { get; set; }

    }
}
