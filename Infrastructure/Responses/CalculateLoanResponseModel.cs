using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Responses
{
    public class CalculateLoanResponseModel
    {
        public decimal Balance { get; set; }
        public decimal Interest { get; set; }
        public decimal Principle { get; set; }
    }
}
