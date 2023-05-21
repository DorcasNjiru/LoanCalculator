using LoanCalc.DAL.Models;
using LoanCalc.DAL.Responses;

namespace LoanCalc.DAL.Services
{
    public interface IUserService
    {
        UserResponse createNewAccount(LoanCalc.DAL.Models.User user);

        LoginResponse AuthenticateUser(string emailAddress, string Password);
    }
}
