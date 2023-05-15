using Infrastructure.InputParams;
using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure.Responses;

namespace Infrastructure
{
    public class ComputeLoan : IComputeLoan

    {
        CalculateLoanResponse IComputeLoan.CalculateLoan(CalculateLoanInput cli)
        {
           return CalculateInstallments(cli);
        }

        public CalculateLoanResponse CalculateInstallments(CalculateLoanInput cli)
        {
            decimal installment = 0;
            decimal totalInterest = 0;
            decimal totalCharges = 0;
            decimal totalLoanAmount = 0;
            decimal processingFees = 3000;
            int interestRate = 20;
            CalculateLoanResponseModel clrm = null;
            List<CalculateLoanResponseModel> lsclrm = new List<CalculateLoanResponseModel>();
            

            // Calculate installment based on interest type (Flat Rate or Reducing Balance)

            if (cli.InterestType == "Flat Rate")
            {
                decimal annualInterestRate = 20;
                decimal monthlyInterestRate = annualInterestRate / 12 / 100;
                int totalPayments = (cli.LoanPeriod / 12) * GetNumberOfPaymentsPerYear(cli.PaymentFrequency);

                decimal bal = 0;
                //installment = (cli.AmountToBorrow + (processingFees + processingFees * 0.2m)) / totalPayments;
                //totalInterest = installment * totalPayments - cli.AmountToBorrow;
                totalInterest = (annualInterestRate /100) * cli.AmountToBorrow;
                totalCharges = processingFees + processingFees * 0.2m + 10000;
                totalLoanAmount = cli.AmountToBorrow + totalInterest + totalCharges;

                installment = totalLoanAmount / totalPayments;

                decimal remainingAmount = totalLoanAmount;
                for (int i = 0; i < totalPayments; i++)
                {

                    bal = totalLoanAmount - installment;
                   //bal = cli.AmountToBorrow - installment- bal;
                   
                    clrm = new CalculateLoanResponseModel();
                    clrm.Balance = remainingAmount;
                    clrm.Interest = totalInterest/totalPayments;
                    clrm.Principle = installment;

                    lsclrm.Add(clrm);
                    remainingAmount -= installment;

                }
            }
            else if (cli.InterestType == "Reducing Balance")
            {
                decimal annualInterestRate = 22;

                decimal monthlyInterestRate = annualInterestRate / 12 / 100;

                int totalPayments = (cli.LoanPeriod / 12) * GetNumberOfPaymentsPerYear(cli.PaymentFrequency);

                decimal remainingAmount = cli.AmountToBorrow;

                //Console.WriteLine($"Amount    |   Remaining");
                for (int i = 0; i < totalPayments; i++)
                {
                    decimal interest = remainingAmount * (monthlyInterestRate*totalPayments);//redo

                    decimal principal = (cli.AmountToBorrow / totalPayments) - interest;

                    //remainingAmount -= principal;

                    installment += principal;
                    totalInterest += interest;

                    clrm= new CalculateLoanResponseModel();
                    clrm.Balance = remainingAmount;
                    clrm.Interest = interest;
                    clrm.Principle = principal;

                    lsclrm.Add(clrm);
                    remainingAmount -= principal;

                    //Console.WriteLine($"{principal}    |   {remainingAmount}");
                    //System.Diagnostics.Debug.WriteLine($"RemainigAmount = {remainingAmount}");
                }

                totalCharges = processingFees + processingFees * 0.2m + 10000;

            }
            return new CalculateLoanResponse(lsclrm, true, "CalculateLoanSuccessful");
        }
        public int GetNumberOfPaymentsPerYear(string paymentFrequency)
        {

            if (paymentFrequency == "Monthly")
            {
                return 12;
            }

            if (paymentFrequency == "Quarterly")
            {
                return 4;
            }

            if (paymentFrequency == "6 Months")
            {
                return 2;
            }

            if (paymentFrequency == "Annually")
            {
                return 1;
            }

            return 1;
        }
    }
}
