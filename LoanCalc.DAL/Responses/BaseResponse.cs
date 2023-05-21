namespace LoanCalc.DAL.Responses
{
    public class BaseResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }


        public BaseResponse(bool bSuccess, string sMessage)
        {
            Success = bSuccess;
            Message = sMessage;

        }
    }
}
