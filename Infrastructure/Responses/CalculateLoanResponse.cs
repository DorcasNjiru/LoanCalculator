using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Responses
{
    public class CalculateLoanResponse
    {
        public List< CalculateLoanResponseModel> Result { get; set; }
        public bool Success{ get; set; }
        public string Message  { get; set; }
        public CalculateLoanResponse(List<CalculateLoanResponseModel> clrm ,bool bSuccessful, string message)
        {
            Result = clrm;
            Success = bSuccessful;
            Message = message;
                
        }
    }

}
