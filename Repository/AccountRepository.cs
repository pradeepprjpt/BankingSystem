using BankingSystem.Entities;
using Microsoft.Extensions.Caching.Memory;

namespace BankingSystem.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private IMemoryCache _inMemoryCache;
        public AccountRepository(IMemoryCache inMemoryCache)
        {
            _inMemoryCache = inMemoryCache;
        }

        public async Task<bool> Create(Account entity)
        {
            _inMemoryCache.Set(entity.AccountNumber, entity);
            return true;
        }

        public async Task<Account> Get(long id)
        {
            if (_inMemoryCache.TryGetValue($"Account:{id}", out Account account))
            {
                return account;
            }

            return new Account();
        }

        public async Task<bool> Close(long id)
        {
            if (_inMemoryCache.TryGetValue($"Account:{id}", out Account account))
            {
                account.Active = false;
                _inMemoryCache.Remove(id);
                _inMemoryCache.CreateEntry(id);

                return true;
            }

            return false;
        }
    }
}
