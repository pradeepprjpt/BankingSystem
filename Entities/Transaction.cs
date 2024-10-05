using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BankingSystem.Entities
{
    public class Transaction
    {
        public long TransactionId { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public TransactionType TransactionType { get; set; }
        public long AccountNumber { get; set; }
        public double AmountDebited { get; set; }
        public double AmountCredited { get; set; }
        public double AmountWithdrawn { get; set; }
        public double AmountDeposited { get; set; }
        public double InterestCredited { get; set; }
        public string Remark { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
    }

    public enum TransactionType
    {
        [Display(Name = "Debit")]
        Debit = 0,

        [Display(Name = "Credit")]
        Credit = 1,

        [Display(Name = "Deposit")]
        Deposit = 2,

        [Display(Name = "Withdraw")]
        Withdraw = 3
    }
}
