using System.Linq;
using System.Threading.Tasks;
using Calculator.Business.Services;
using Calculator.Dto.Dto;
using Calculator.Dto.Request;
using Calculator.Dto.Response;
using FluentValidation;
using Serilog;

namespace Calculator.Business.Manager
{
  public class LoanCalculatorManager : ILoanCalculatorManager
  {
    private readonly IValidator<CalculateLoanRequest> loanCalculationValidator;
    private readonly ILogger logger;
    private readonly ILoanTypeService loanTypeService;
    private readonly IInstallmentService installmentService;

    public LoanCalculatorManager(IValidator<CalculateLoanRequest> loanCalculationValidator, 
      ILogger logger, 
      ILoanTypeService loanTypeService,
      IInstallmentService installmentService)
    {
      this.loanCalculationValidator = loanCalculationValidator;
      this.logger = logger;
      this.loanTypeService = loanTypeService;
      this.installmentService = installmentService;
    }
    public async Task<LoanCalculationResult> CalculateAsync(CalculateLoanRequest request)
    {
      this.logger.Debug("Calculating the payback plan for params: {@Params}", request);
      await this.loanCalculationValidator.ValidateAndThrowAsync(request);

      var loanType = await this.loanTypeService.GetLoanTypeOrFailAsync(request.Type);
      var installments = await this.installmentService.GetInstallmentPlanAsync(request.Value, request.Period, request.PeriodType, loanType.InterestRate, request.PaybackPlan);

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