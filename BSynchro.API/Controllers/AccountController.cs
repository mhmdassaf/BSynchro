using BSynchro.BAL.Interfaces;
using BSynchro.Common.Models;
using BSynchro.Common.Models.Account;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BSynchro.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AccountController : ControllerBase
    {

        private readonly ILogger<AccountController> _logger;
        private readonly IAccountService _accountService;
        public AccountController(ILogger<AccountController> logger, IAccountService accountService)
        {
            _logger = logger;
            _accountService = accountService;
        }

        [HttpPost]
        public async Task<IActionResult> OpenNewAccount(OpenNewAccountInput input)
        {
            var response = new ApiResponse();
            try
            {
                OpenNewAccountOutput res = await _accountService.OpenNewAccount(input);
                response.Result = res;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                response.Code = (int)HttpStatusCode.InternalServerError;
                response.Message = "SOMETHING_HAPPEND_IN_SERVER";
                response.Flag = Flag.Fail;
            }
            return StatusCode(response.Code, response);
        }
      
    }
}