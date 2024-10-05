using BankingSystem.Entities;

namespace BankingSystem.Dtos
{
    public class TransactionDto
    {
        public long TransactionId { get; set; }
        public string TransactionType { get; set; }
        public long AccountNumber { get; set; }
        public double Balance { get; set; }
        public double AmountDebited { get; set; }
        public double AmountCredited { get; set; }
        public double AmountWithdrawn { get; set; }
        public double AmountDeposited { get; set; }
        public double InterestCredited { get; set; }
        public string Remark { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
