using BankingSystem.Entities;

namespace BankingSystem.Repository
{
    public interface ICustomerRepository 
    {
        Task<Customer> Get(long id);
        Task<bool> Create(Customer customer);
        Task<bool> Close(long id);
    }
}
