// // <copyright file="LoanCalculatorService.cs" company="CodePlus Software">
// // Copyright(c) 2021 All Right Reserved
// // </copyright>
// // <author>Szymon Hełmecki</author>
// // <date>26-01-2021</date>
// // <summary>LoanCalculatorService.cs</summary>

using System.Threading.Tasks;
using Calculator.Dto.Dto;
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

      const decimal interestRate = 3.5m;

      var months = request.Period * 12;

      var response = new LoanCalculationResponse();
      var capitalInstallment = request.Amount / months;

      var totalAmount = request.Amount;
      var fixedAmount = request.Amount;
      
      //https://enerad.pl/finanse/kredyt-hipoteczny/jak-obliczyc-raty-i-odsetki-od-kredytu-hipotecznego/
      for (int i = 0; i < months; i++)
      {
        var interest = (((totalAmount - i * capitalInstallment)/100 * interestRate)) / 12;
        var installment = new InstallmentDto
        {
          Capital = capitalInstallment,
          Interest = interest
        };
        response.Installments.Add(installment);
      }

      return response;
    }
  }
}