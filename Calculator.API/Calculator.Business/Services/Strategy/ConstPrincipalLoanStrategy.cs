using System;
using System.Collections.Generic;
using Calculator.Business.Models;

namespace Calculator.Business.Services.Strategy
{
  public class ConstPrincipalLoanStrategy : IConstPrincipalLoanStrategy
  {
    public IList<Installment> Generate(decimal amount, int months, float interestRatePercentage)
    {
      var installments = new List<Installment>();
      var principalAmount = amount / months;
      var interestRateVal = (decimal) interestRatePercentage / 100;
      
      var totalAmount = amount;
      for (var installmentNo = 0; installmentNo < months; installmentNo++)
      {
        var interest = (totalAmount - installmentNo * principalAmount) * interestRateVal / 12;
        var installment = new Installment
        {
          Principal = principalAmount,
          Interest = interest,
          InstallmentDate = DateTime.Now.AddMonths(installmentNo)
        };
        installments.Add(installment);
      }

      return installments;
    }
  }
}