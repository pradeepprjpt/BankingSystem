using BankingSystem.Entities;

namespace BankingSystem.Repository
{
    public interface IAccountRepository
    {
        Task<Account> Get(long id);
        Task<bool> Create(Account account);
        Task<bool> Close(long id);
    }
}
