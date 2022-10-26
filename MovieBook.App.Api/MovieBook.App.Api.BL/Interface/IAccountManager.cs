using MovieBook.App.Api.Models.DTO.Classes;

namespace MovieBook.App.Api.BL.Interface
{
    public interface IAccountManager
    {
        string GetToken(UserCredentials userCredential);

        bool Register(UserRegister userRegister);
    }
}
