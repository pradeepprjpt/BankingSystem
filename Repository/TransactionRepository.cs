using BankingSystem.Entities;
using Microsoft.Extensions.Caching.Memory;

namespace BankingSystem.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        private IMemoryCache _memoryCache;
        public TransactionRepository(IMemoryCache memoryCache) 
        { 
            _memoryCache = memoryCache;
        }
        public async Task<bool> Create(Transaction transaction)
        {
            _memoryCache.Set($"Transaction{transaction.AccountNumber}", transaction);
            return true;
        }

        public async Task<List<Transaction>> GetAll(long accountNumber)
        {
            if (_memoryCache.TryGetValue($"Transaction{accountNumber}", out List<Transaction> transactions))
            {
                return transactions;
            }

            return [];
        }
    }
}
