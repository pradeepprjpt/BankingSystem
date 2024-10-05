namespace BankingSystem.Dtos
{
    public class CustomerDto
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
        public DateTime? ModifiedOn { get; set; }
    }
}
