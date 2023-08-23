namespace ProjektTaiibWeb.DTO
{
    public class UserDetails
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public int? LocalNumber { get; set; }
        public string Payment { get; set; }
        public string? AdditionalInformation { get; set; }

    }
}
