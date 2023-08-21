namespace ProjektTaiibWeb.DTO
{
    public record class RegisterRequest(string Email, string LoginRegister,string PasswordRegister,
        string? Name,string? Surname, string? PhoneNumber, string? ZIPCode,string? Country, string? City,
        string? Street, int HouseNumber, int? LocalNumber, string? Payment, string? AdditionalInformation);
   
}
