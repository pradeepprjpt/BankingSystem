using BankingSystem.Dtos;
using BankingSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace BankingSystem.Controllers
{
    [ApiController]
    [Route("api/money-management")]
    public class MoneyManagementController : Controller
    {
        private IMoneyManagementService _moneyManagement;

        public MoneyManagementController(MoneyManagementService moneyManagement)
        {
            _moneyManagement = moneyManagement;
        }

        [Route("create-transaction")]
        [HttpPost]
        public async Task<IActionResult> CreateTransaction([FromBody] CreateTransactionDto request)
        {
            await _moneyManagement.CreateTransaction(request).ConfigureAwait(false);
            return Ok();
        }

        [Route("get-transaction/{accountNumber}")]
        [HttpGet]
        public async Task<IActionResult> GetTransaction(long accountNumber)
        {
            var transactions = await _moneyManagement.GetTransactions(accountNumber);
            return Ok(transactions);
        }
    }
}
