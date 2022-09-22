using BSynchro.BAL.Commands;
using BSynchro.BAL.Interfaces;
using BSynchro.BAL.Queries;
using BSynchro.Common.Models;
using BSynchro.Common.Models.Account;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BSynchro.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<AccountController> _logger;
        private readonly IAccountService _accountService;
        public AccountController(IMediator mediator,ILogger<AccountController> logger, IAccountService accountService)
        {
            _mediator = mediator;
            _logger = logger;
            _accountService = accountService;
        }

        /// <summary>
        /// List all exsting customers on database
        /// </summary>
        /// <returns>list of customers</returns>
        [HttpGet]
        public async Task<IActionResult> CustomerList()
        {
            var response = new ApiResponse();
            try
            {
                var output = await _mediator.Send(new CustomerListQuery());
                //List<CustomerListOutput> output = await _accountService.CustomerList();
                response.Result = output;

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

        /// <summary>
        /// Create new banking account based on customer id and InitialCredit inputs. 
        /// If  InitialCredit positive then new transaction will created
        /// </summary>
        /// <param name="input">the id of customer and initial credit of the new account</param>
        /// <returns>Response message either success or failure</returns>
        [HttpPost]
        public async Task<IActionResult> OpenNewAccount(OpenNewAccountInput input)
        {
            var response = new ApiResponse();
            try
            {
                OpenNewAccountOutput res = await _mediator.Send(new OpenNewAccountCommand(input));
                //OpenNewAccountOutput res = await _accountService.OpenNewAccount(input);
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