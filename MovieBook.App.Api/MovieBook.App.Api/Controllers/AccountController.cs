using Microsoft.AspNetCore.Mvc;
using MovieBook.App.Api.BL.Interface;
using MovieBook.App.Api.Models;
using MovieBook.App.Api.Models.DTO.Classes;

namespace MovieBook.App.Api.Controllers
{

    [ApiController]
    [Route("api/Account")]
    public class AccountController : ControllerBase
    {

        private readonly IAccountManager _accountManager;
        private readonly ILogger<AccountController> _logger;
        public AccountController(ILogger<AccountController> logger, IAccountManager accountManager)
        {
            _logger = logger;
            _accountManager = accountManager;
        }


        [Route("Authenticate")]
        [HttpPost]
        public async Task<IActionResult> Authenticate([FromBody] UserCredentials userCredentials)
        {
            
            return Ok(_accountManager.GetToken(userCredentials));
        }

        [Route("Register")]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] UserRegister userRegister)
        {

            return Ok(_accountManager.Register(userRegister));
        }
    }
}
