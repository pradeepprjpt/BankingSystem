using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace BankingSystem.Entities
{
    public class Account
    {
        public long AccountNumber { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public AccountType AccountType { get; set; }
        public double Balance { get; set; }
        public double InterestCredited { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
    }

    public enum AccountType
    {
        [Display(Name = "Saving")]
        Saving = 0,

        [Display(Name = "Checking")]
        Checking = 1
    }
}
