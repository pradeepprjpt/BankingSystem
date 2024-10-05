using BankingSystem.Entities;

namespace BankingSystem.Dtos
{
    public class CreateAccountDto
    {
        public AccountType AccountType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PanCardNumber { get; set; }
        public string Email { get; set; }
        public string PostalCode { get; set; }
        public int PhoneNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
    }
}
