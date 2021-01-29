using System;
using System.Collections.Generic;
using Calculator.Business.Exceptions;
using Calculator.Business.Models;

namespace Calculator.Business.Services.Strategy
{
  public class ConstPrincipalLoanStrategy : IConstPrincipalLoanStrategy
  {
    public IList<Installment> Generate(decimal totalAmount, int months, float interestRatePercentage)
    {
      if (months <= 0)
      {
        throw new InvalidPeriodException();
      }

      var principalAmount = totalAmount / months;
      var interestRateVal = (decimal) interestRatePercentage / 100;

      var installments = GenerateInstallments(totalAmount, months, principalAmount, interestRateVal);
      return installments;
    }

    private static IList<Installment> GenerateInstallments(decimal totalAmount, int months, decimal principalAmount,
      decimal interestRateVal)
    {
      var installments = new List<Installment>();
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