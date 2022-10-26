using MovieBook.App.Api.Core.Entities;
using MovieBook.App.Api.Models.DTO.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBook.App.Api.Core.Interface
{
    public interface IAccountService
    {
        UserAccount GetUser(UserCredentials userCredentials);
        bool RegisterUser(UserRegister userRegister);

    }
}
