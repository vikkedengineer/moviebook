using MovieBook.App.Api.BL.Interface;
using MovieBook.App.Api.Core.Interface;
using MovieBook.App.Api.Models.DTO.Classes;
using System.IdentityModel.Tokens.Jwt;

namespace MovieBook.App.Api.BL.ServiceManager
{
    public class AccountManager: IAccountManager
    {
        private readonly IAccountService _accountService;
        public AccountManager(IAccountService accountService)
        {
            _accountService = accountService;
        }
        public string GetToken(UserCredentials userCredential)
        {
            string token = null;
        
            var userData = _accountService.GetUser(userCredential);
            if (userData != null)
            {
                var jwt = new JwtSecurityToken();
                token = new JwtSecurityTokenHandler().WriteToken(jwt);
            }
            else
            {
                token = "Incorrect username or password";
            }
            return token;

        }
        public bool Register(UserRegister userRegister)
        {

            return _accountService.RegisterUser(userRegister);
            

        }

    }
}
