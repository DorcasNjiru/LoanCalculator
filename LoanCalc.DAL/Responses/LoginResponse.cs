using LoanCalc.DAL.Models;

namespace LoanCalc.DAL.Responses
{
    public class LoginResponse : BaseResponse
    {

        public string Token { get; set; } = string.Empty;

        public User User { get; set; }
        public LoginResponse(bool bSuccess, string sMessage, string sToken, User user) : base(bSuccess, sMessage)
        {
            Token = sToken;
            User = user;
        }
    }
}
