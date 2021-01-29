using System.Linq;
using System.Threading.Tasks;
using Calculator.Business.Services;
using Calculator.Dto.Dto;
using Calculator.Dto.Enum;
using Calculator.Dto.Request;
using Calculator.Dto.Response;
using FluentValidation;
using Serilog;

namespace Calculator.Business.Manager
{
  public class LoanCalculatorManager : ILoanCalculatorManager
  {
    private readonly IInstallmentService installmentService;
    private readonly IValidator<CalculateLoanRequest> loanCalculationValidator;
    private readonly ILoanService loanService;
    private readonly ILogger logger;

    public LoanCalculatorManager(IValidator<CalculateLoanRequest> loanCalculationValidator,
      ILogger logger,
      ILoanService loanService,
      IInstallmentService installmentService)
    {
      this.loanCalculationValidator = loanCalculationValidator;
      this.logger = logger;
      this.loanService = loanService;
      this.installmentService = installmentService;
    }

    public async Task<LoanCalculationResult> CalculateAsync(CalculateLoanRequest request)
    {
      logger.Debug("Calculating the payback plan for params: {@Params}", request);
      await loanCalculationValidator.ValidateAndThrowAsync(request);

      var loanType = await loanService.GetLoanTypeOrFailAsync(request.Type);

      var months = request.PeriodType == EPeriodType.Year ? request.Period * 12 : request.Period;
      var installments =
        await installmentService.GetInstallmentPlanAsync(request.Value, months, loanType.InterestRate,
          request.PaybackPlan);

      var response = new LoanCalculationResult
      {
        TotalPrincipal = installments.Sum(x => x.Principal),
        TotalInterest = installments.Sum(x => x.Interest),
        TotalPayment = installments.Sum(x => x.Payment),
        Installments = installments.Select(x => new InstallmentDto
        {
          Interest = x.Interest,
          Principal = x.Principal,
          Payment = x.Payment,
          InstallmentDate = x.InstallmentDate
        })
      };
      return response;
    }
  }
}