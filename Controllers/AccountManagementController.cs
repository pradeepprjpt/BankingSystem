using BankingSystem.Dtos;
using BankingSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace BankingSystem.Controllers
{
    [ApiController]
    [Route("api/account-management")]
    public class AccountManagementController : Controller
    {
        private readonly IAccountManagementService _accountManagementService;
        public AccountManagementController(IAccountManagementService accountManagementService)
        {
            _accountManagementService = accountManagementService;
        }

        [Route("create-account")]
        [HttpPost]
        public async Task<IActionResult> CreateAccount([FromBody] CreateAccountDto request)
        {
            await _accountManagementService.CreateAccount(request).ConfigureAwait(false);
            return Ok();
        }

        [Route("create-account-for-existing-customer")]
        [HttpPost]
        public async Task<IActionResult> CreateAccountForExistingCustomer([FromBody] CreateAccountForExistingCustomer request)
        {
            await _accountManagementService.CreateAccountForExistingCustomer(request).ConfigureAwait(false);
            return Ok();
        }

        [Route("get-account/{accountNumber}")]
        [HttpGet]
        public async Task<IActionResult> GetAccount(long accountNumber)
        {
            var account = await _accountManagementService.GetAccount(accountNumber).ConfigureAwait(false);
            return Ok(account);
        }

        [Route("get-customer/{customerId}")]
        [HttpGet]
        public async Task<IActionResult> GetCustomer(long customerId)
        {
            var customer = await _accountManagementService.GetCustomer(customerId).ConfigureAwait(false);
            return Ok(customer);
        }
    }
}
