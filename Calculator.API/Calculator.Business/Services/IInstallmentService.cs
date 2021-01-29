using System.Collections.Generic;
using System.Threading.Tasks;
using Calculator.Business.Models;
using Calculator.Dto.Enum;

namespace Calculator.Business.Services
{
  public interface IInstallmentService
  {
    Task<IList<Installment>> GetInstallmentPlanAsync(decimal amount, int months, float interestRate,
      EPaybackPlan paybackPlan);
  }
}