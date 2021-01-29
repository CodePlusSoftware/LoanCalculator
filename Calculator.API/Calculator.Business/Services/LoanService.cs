using System.Threading.Tasks;
using Calculator.Business.Exceptions;
using Calculator.Core;
using Calculator.Core.Entity;
using Calculator.Dto.Enum;
using Microsoft.EntityFrameworkCore;

namespace Calculator.Business.Services
{
  public class LoanService : ILoanService
  {
    private readonly LoanDbContext loanDbContext;

    public LoanService(LoanDbContext loanDbContext)
    {
      this.loanDbContext = loanDbContext;
    }

    public async Task<LoanTypeEntity> GetLoanTypeOrFailAsync(ELoanType type)
    {
      var loanTypeName = type.ToString();
      var loanType = await loanDbContext.LoanType.FirstOrDefaultAsync(x => x.Name == loanTypeName);

      if (loanType is null) throw new ItemNotFoundException("Loan type not found");

      return loanType;
    }
  }
}