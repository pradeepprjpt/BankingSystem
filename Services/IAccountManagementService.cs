using BankingSystem.Dtos;

namespace BankingSystem.Services
{
    public interface IAccountManagementService
    {
        Task<bool> CreateAccount(CreateAccountDto request);
        Task<bool> CreateAccountForExistingCustomer(CreateAccountForExistingCustomer request);
        Task<AccountDto> GetAccount(long accountNumber);
        Task<CustomerDto> GetCustomer(long id);
       Task<bool> CloseAccount( long accountNumber);
    }
}
