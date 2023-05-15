using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure.InputParams;
using Infrastructure.Responses;

namespace Infrastructure
{
    public interface IComputeLoan
    {
        CalculateLoanResponse CalculateLoan(CalculateLoanInput cli);

    
    }
}
