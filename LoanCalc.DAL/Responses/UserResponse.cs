using LoanCalc.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanCalc.DAL.Responses
{
    public class UserResponse : BaseResponse
    {
        public User Result { get; set; }

        public UserResponse(User user, bool bSuccessful, string message) : base(bSuccessful, message)
        {
            Result = user;

        }
    }
}

