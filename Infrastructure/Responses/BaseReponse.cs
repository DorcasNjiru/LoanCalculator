using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Responses
{


    public class BaseReponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }


        public BaseReponse(bool bSuccess, string sMessage)
        {
            Success = bSuccess;
            Message = sMessage;

        }
    }
}
