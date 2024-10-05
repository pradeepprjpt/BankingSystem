using AutoMapper;
using BankingSystem.Dtos;
using BankingSystem.Entities;
using BankingSystem.Repository;

namespace BankingSystem.Services
{
    public class MoneyManagementService : IMoneyManagementService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;
        private readonly Random _random;

        public MoneyManagementService(
            IAccountRepository accountRepository,
            ITransactionRepository transactionRepository,
                IMapper mapper)
        {
            _accountRepository = accountRepository;
            _transactionRepository = transactionRepository;
            _mapper = mapper;
            _random = new Random();
        }

        public async Task<bool> CreateTransaction(CreateTransactionDto request)
        {
            var transaction = _mapper.Map<Transaction>(request);
            transaction.TransactionId = _random.NextInt64();

            var account = await _accountRepository.Get(transaction.AccountNumber);

            switch (request.TransactionType)
            {
                case TransactionType.Debit:
                    if (account.Balance < request.AmountDebited)
                    {
                        throw new InvalidOperationException("Transaction absconded due to insufficient fund.");
                    }

                    account.Balance -= request.AmountDebited;
                    account.ModifiedOn = DateTime.Now;
                    account.ModifiedBy = "System";

                    transaction.Remark = $" {request.AmountDebited} Amount debited from your account.";
                    transaction.CreatedOn = DateTime.Now;
                    transaction.CreatedBy = "System";
                    break;
                case TransactionType.Credit:
                    account.Balance += request.AmountCredited;
                    account.ModifiedOn = DateTime.Now;
                    account.ModifiedBy = "System";

                    transaction.Remark = $" {request.AmountCredited} Amount credited to your account.";
                    transaction.CreatedOn = DateTime.Now;
                    transaction.CreatedBy = "System";
                    break;
                case TransactionType.Deposit:
                    account.Balance += request.AmountDeposited;
                    account.ModifiedOn = DateTime.Now;
                    account.ModifiedBy = "System";

                    transaction.Remark = $" {request.AmountDeposited} Amount deposited to your account.";
                    transaction.CreatedOn = DateTime.Now;
                    transaction.CreatedBy = "System";
                    break;
                case TransactionType.Withdraw:
                    if (account.Balance < request.AmountWithdrawn)
                    {
                        throw new InvalidOperationException("Transaction absconded due to insufficient fund.");
                    }

                    account.Balance -= request.AmountWithdrawn;
                    account.ModifiedOn = DateTime.Now;
                    account.ModifiedBy = "System";

                    transaction.Remark = $" {request.AmountWithdrawn} Amount withdrawn from your account.";
                    transaction.CreatedOn = DateTime.Now;
                    transaction.CreatedBy = "System";
                    break;
                default: break;
            }

            await _accountRepository.Create(account).ConfigureAwait(false);
            var result = await _transactionRepository.Create(transaction).ConfigureAwait(false);
            return result;
        }

        public async Task<List<TransactionDto>> GetTransactions(long accountNumber)
        {
            var transactions = await _transactionRepository.GetAll(accountNumber).ConfigureAwait(false);
            var result = _mapper.Map<List<TransactionDto>>(transactions);
            return result;
        }
    }
}
