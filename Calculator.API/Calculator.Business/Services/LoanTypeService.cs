using System.Threading.Tasks;
using Calculator.Business.Exceptions;
using Calculator.Core;
using Calculator.Core.Entity;
using Calculator.Dto.Enum;
using Microsoft.EntityFrameworkCore;

namespace Calculator.Business.Services
{
  public class LoanTypeService : ILoanTypeService
  {
    private readonly CalculatorDbContext dbContext;

    public LoanTypeService(CalculatorDbContext dbContext)
    {
      this.dbContext = dbContext;
    }

    public async Task<LoanType> GetLoanTypeOrFailAsync(ELoanType type)
    {
      var loanTypeName = type.ToString();
      var loanType = await this.dbContext.LoanType.FirstOrDefaultAsync(x => x.Name == loanTypeName);

      if (loanType is null)
      {
        throw new ItemNotFoundException("Loan type not found");
      }

      return loanType;
    }
  }
}