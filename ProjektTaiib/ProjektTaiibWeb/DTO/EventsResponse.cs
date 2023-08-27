namespace ProjektTaiibWeb.DTO
{
    public class EventsResponse
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal TicketPrice { get; set; }
        public int AmountTicket { get; set; }
        public List<string> Sponsors { get; set; }

    }
}
