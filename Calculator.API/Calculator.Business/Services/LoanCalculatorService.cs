// // <copyright file="LoanCalculatorService.cs" company="CodePlus Software">
// // Copyright(c) 2021 All Right Reserved
// // </copyright>
// // <author>Szymon Hełmecki</author>
// // <date>26-01-2021</date>
// // <summary>LoanCalculatorService.cs</summary>

using System.Threading.Tasks;
using Calculator.Dto.Request;
using Calculator.Dto.Response;
using FluentValidation;
using Serilog;

namespace Calculator.Business.Services
{
  public class LoanCalculatorService : ILoanCalculatorService
  {
    private readonly IValidator<LoanCalculationRequest> loanCalculationValidator;
    private readonly ILogger logger;

    public LoanCalculatorService(IValidator<LoanCalculationRequest> loanCalculationValidator, ILogger logger)
    {
      this.loanCalculationValidator = loanCalculationValidator;
      this.logger = logger;
    }
    public async Task<LoanCalculationResponse> Calculate(LoanCalculationRequest request)
    {
      this.logger.Debug("Calculating the payback plan for params: {@Params}", request);
      await this.loanCalculationValidator.ValidateAndThrowAsync(request);
      return new LoanCalculationResponse
      {
        
      };
    }
  }
}