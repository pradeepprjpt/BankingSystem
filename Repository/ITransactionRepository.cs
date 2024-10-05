using BankingSystem.Entities;

namespace BankingSystem.Repository
{
    public interface ITransactionRepository
    {
        Task<bool> Create(Transaction transaction);
        Task<List<Transaction>> GetAll(long accountNumber);
    }
}
