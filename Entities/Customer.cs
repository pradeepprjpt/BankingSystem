namespace BankingSystem.Entities
{
    public class Customer
    {
        public long Id { get; set; }
        public List<long> AccountNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PanCardNumber { get; set; }
        public string Email { get; set; }
        public string PostalCode { get; set; }
        public int PhoneNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
    }
}
