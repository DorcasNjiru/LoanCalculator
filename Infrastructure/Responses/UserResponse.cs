using Infrastructure.ResponseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Responses
{
    internal class UserResponse : BaseReponse
    {
        public UserResponseModel Result { get; set; }

        public UserResponse(UserResponseModel user, bool bSuccessful, string message) : base(bSuccessful, message)
        {
            Result = user;

        }
    }
}

