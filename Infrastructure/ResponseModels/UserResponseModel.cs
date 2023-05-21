using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.ResponseModels
{
    public class UserResponseModel
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string EmailAddress { get; set; }
    }
}
