namespace ProjektTaiibWeb.DTO
{
    public struct ticketInfo
    {
        public int NormalTicket { get; set; }
        public int NormalPremiumTicket { get; set; }

        public int ReducedTicket { get; set; }
        public int ReducedPremiumTicket { get; set; }
    }
    public class TicketInfo
    {
        public double TicketPrice { get; set; }
        
        public ticketInfo ticketInfo { get; set; }
    }
}
