using BankingSystem.Entities;

namespace BankingSystem.Dtos
{
    public class AccountDto
    {
        public long AccountNumber { get; set; }
        public string AccountType { get; set; }
        public bool Active { get; set; }
        public DateTime CreateOn { get; set; }
    }
}
