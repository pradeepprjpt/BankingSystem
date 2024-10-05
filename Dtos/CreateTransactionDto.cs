using BankingSystem.Entities;

namespace BankingSystem.Dtos
{
    public class CreateTransactionDto
    {
        public TransactionType TransactionType { get; set; }
        public long AccountNumber { get; set; }
        public double AmountDebited { get; set; }
        public double AmountCredited { get; set; }
        public double AmountWithdrawn { get; set; }
        public double AmountDeposited { get; set; }
        public string Remark { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
