using AutoMapper;
using BankingSystem.Dtos;
using BankingSystem.Entities;
using BankingSystem.Repository;

namespace BankingSystem.Services
{
    public class AccountManagementService : IAccountManagementService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;
        private readonly Random _random;

        public AccountManagementService(IAccountRepository accountRepository,
            ICustomerRepository customerRepository,
            ITransactionRepository transactionRepository,
            IMapper mapper)
        {
            _accountRepository = accountRepository;
            _customerRepository = customerRepository;
            _transactionRepository = transactionRepository;
            _mapper = mapper;
            _random = new Random();
        }

        public async Task<bool> CreateAccount(CreateAccountDto request)
        {
            var customer = _mapper.Map<Customer>(request);
            customer.IsActive = true;
            var accountNumber = _random.NextInt64();
            customer.AccountNumber = new List<long> { accountNumber };
            customer.Id = _random.NextInt64();
            customer.CreatedOn = DateTime.Now;
            customer.CreatedBy = "System";

            var isCustomerCreated = await _customerRepository.Create(customer).ConfigureAwait(false);

            if (isCustomerCreated)
            {
                var account = _mapper.Map<Account>(request);
                account.AccountNumber = accountNumber;
                account.Active = true;
                account.CreatedOn = DateTime.Now;
                account.CreatedBy = "System";

                var isAccountCreated = await _accountRepository.Create(account).ConfigureAwait(false);
                if (isAccountCreated)
                {
                    return true;
                }
            }

            return false;
        }

        public async Task<bool> CreateAccountForExistingCustomer(CreateAccountForExistingCustomer request)
        {
            var customer = await _customerRepository.Get(request.CustomerId).ConfigureAwait(false);
            if (customer != null && customer.AccountNumber.Count < 2)
            {
                var existingAccount = await _accountRepository.Get(customer.AccountNumber.First()).ConfigureAwait(false);
                if (existingAccount is null || (!string.Equals(existingAccount.AccountType.ToString(), request.AccountType.ToString())))
                {
                    var account = _mapper.Map<Account>(request);
                    account.AccountNumber = _random.NextInt64();
                    account.AccountType = request.AccountType;
                    account.Active = true;
                    account.CreatedOn = DateTime.Now;
                    account.CreatedBy = "System";

                    var accountCreated = await _accountRepository.Create(account).ConfigureAwait(false);
                    if (accountCreated)
                    {
                        customer.AccountNumber.Add(account.AccountNumber);
                        await _customerRepository.Create(customer).ConfigureAwait(false);
                        return true;
                    }
                }
            }

            return false;
        }

        public async Task<bool> CloseAccount(long accountNumber)
        {
            var account = await _accountRepository.Get(accountNumber).ConfigureAwait(false);
            if (account is not null)
            {
                if (account.Balance <= 0)
                {
                    var isDisabled = await _accountRepository.Close(accountNumber).ConfigureAwait(false);
                    return true;
                }
            }

            return false;
        }

        public async Task<AccountDto> GetAccount(long accountNumber)
        {
            var account = await _accountRepository.Get(accountNumber).ConfigureAwait(false);
            var accountDto = _mapper.Map<AccountDto>(account);

            return accountDto;
        }

        public async Task<CustomerDto> GetCustomer(long id)
        {
            var customer = await _customerRepository.Get(id).ConfigureAwait(false);
            var customerDto = _mapper.Map<CustomerDto>(customer);

            return customerDto;
        }
    }
}
