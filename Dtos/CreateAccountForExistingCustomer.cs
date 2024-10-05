using BankingSystem.Entities;

namespace BankingSystem.Dtos
{
    public class CreateAccountForExistingCustomer
    {
        public long CustomerId { get; set; } 
        public AccountType AccountType { get; set; }
    }
}
