using System.Collections.Generic;
using Calculator.Business.Models;

namespace Calculator.Business.Services.Strategy
{
  public interface IConstPrincipalLoanStrategy
  {
    IList<Installment> Generate(decimal amount, int months, float interestRate);
  }
}