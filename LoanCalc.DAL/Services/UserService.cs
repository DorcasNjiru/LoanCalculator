using LoanCalc.DAL.Context;
using LoanCalc.DAL.Models;
using LoanCalc.DAL.Responses;

namespace LoanCalc.DAL.Services
{
    public class UserService : IUserService
    {
        private readonly LoanCalcContext _dbContext;
        public UserService(LoanCalcContext dbContext)
        {
            _dbContext = dbContext;
                
        }

        public LoginResponse AuthenticateUser(string emailAddress, string Password)
        {
            
            var user = _dbContext.Users.FirstOrDefault(user => user.EmailAddress == emailAddress);

            if(user != null)
            {

                User _user = new User();

                _user.EmailAddress = emailAddress;
                _user.UserName = user.UserName;
                _user.UserId = user.UserId; 

                return new LoginResponse(true, "success", "",_user);
            }

            return new LoginResponse(false, "success", "", null); 
        }

        UserResponse IUserService.createNewAccount(User user)
        {
            if(user != null)
            {

                _dbContext.Users.Add(user);
                _dbContext.SaveChanges();
                
            }

            return new UserResponse(user, true, "success");
        }
    }
}
