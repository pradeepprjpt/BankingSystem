using BankingSystem.Entities;
using Microsoft.Extensions.Caching.Memory;

namespace BankingSystem.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private IMemoryCache _inMemoryCache;
        private IAccountRepository _accountRepository;
        public CustomerRepository(IMemoryCache inMemoryCache, IAccountRepository accountRepository)
        {
            _inMemoryCache = inMemoryCache;
            _accountRepository = accountRepository;
        }

        public async Task<bool> Create(Customer entity)
        {
            _inMemoryCache.Set($"Customer:{entity.Id}", entity);
            return true;
        }



        public async Task<bool> Close(long id)
        {
            if (_inMemoryCache.TryGetValue<Customer>($"Customer:{id}", out Customer customer))
            {
                customer.IsActive = false;

                //Remove accounts associated with customers
                foreach (var accountId in customer.AccountNumber)
                {
                   await _accountRepository.Close(accountId).ConfigureAwait(false);
                }

                _inMemoryCache.Remove(id);

                return true;
            }

            return false;
        }

        public async Task<Customer> Get(long id)
        {
           if(_inMemoryCache.TryGetValue($"Customer:{id}", out Customer customer))
            {
                return customer;
            }

           return new Customer();
        }


    }
}
