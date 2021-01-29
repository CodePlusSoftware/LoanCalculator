using System.Threading.Tasks;
using Calculator.Dto.Request;
using Calculator.Dto.Response;

namespace Calculator.Business.Manager
{
  public interface ILoanCalculatorManager
  {
    Task<LoanCalculationResult> CalculateAsync(CalculateLoanRequest request);
  }
}