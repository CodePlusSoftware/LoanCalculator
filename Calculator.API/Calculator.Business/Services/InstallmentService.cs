using System.Collections.Generic;
using System.Threading.Tasks;
using Calculator.Business.Exceptions;
using Calculator.Business.Models;
using Calculator.Business.Services.Strategy;
using Calculator.Dto.Enum;

namespace Calculator.Business.Services
{
  public class InstallmentService : IInstallmentService
  {
    private readonly IConstPrincipalLoanStrategy constPrincipalLoanStrategy;

    public InstallmentService(IConstPrincipalLoanStrategy constPrincipalLoanStrategy)
    {
      this.constPrincipalLoanStrategy = constPrincipalLoanStrategy;
    }

    public Task<IList<Installment>> GetInstallmentPlanAsync(decimal amount, int months,
      float interestRate, EPaybackPlan paybackPlan)
    {
      var installments = paybackPlan switch
      {
        EPaybackPlan.ConstPrincipalAmount => constPrincipalLoanStrategy.Generate(amount, months, interestRate),
        _ => throw new UndefinedPlanException($"$Unknown payback plan{paybackPlan}")
      };

      return Task.FromResult(installments);
    }
  }
}