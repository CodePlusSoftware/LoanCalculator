using System.Threading.Tasks;
using Calculator.Core.Entity;
using Calculator.Dto.Enum;

namespace Calculator.Business.Services
{
  public interface ILoanTypeService
  {
    Task<LoanType> GetLoanTypeOrFailAsync(ELoanType type);
  }
}