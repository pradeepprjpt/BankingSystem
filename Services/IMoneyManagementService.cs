using BankingSystem.Dtos;

namespace BankingSystem.Services
{
    public interface IMoneyManagementService
    {
        Task<bool> CreateTransaction(CreateTransactionDto request);
        Task<List<TransactionDto>> GetTransactions(long accountNumber);
    }
}
