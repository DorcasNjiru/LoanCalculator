using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.InputParams
{
    public class CalculateLoanInput
    {
        public string Bank { get; set; }
        public decimal AmountToBorrow { get; set; }
        public string PaymentFrequency { get; set; }
        public int LoanPeriod { get; set; }
        public DateTime StartDate { get; set; }
        public string InterestType { get; set; }
    }
}
