// // <copyright file="LoanCalculatorService.cs" company="CodePlus Software">
// // Copyright(c) 2021 All Right Reserved
// // </copyright>
// // <author>Szymon Hełmecki</author>
// // <date>26-01-2021</date>
// // <summary>LoanCalculatorService.cs</summary>

using System;
using System.Linq;
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
    private readonly IValidator<CalculateCreditRequest> loanCalculationValidator;
    private readonly ILogger logger;

    public LoanCalculatorService(IValidator<CalculateCreditRequest> loanCalculationValidator, ILogger logger)
    {
      this.loanCalculationValidator = loanCalculationValidator;
      this.logger = logger;
    }
    public async Task<LoanCalculationResult> CalculateAsync(CalculateCreditRequest request)
    {
      this.logger.Debug("Calculating the payback plan for params: {@Params}", request);
      await this.loanCalculationValidator.ValidateAndThrowAsync(request);

      const decimal interestRate = 3.5m;

      var months = request.Period * 12;

      var response = new LoanCalculationResult();
      var capitalInstallment = request.Value / months;

      var totalAmount = request.Value;
      var fixedAmount = request.Value;
      
      //https://enerad.pl/finanse/kredyt-hipoteczny/jak-obliczyc-raty-i-odsetki-od-kredytu-hipotecznego/
      for (int i = 0; i < months; i++)
      {
        var interest = (((totalAmount - i * capitalInstallment)/100 * interestRate)) / 12;
        var installment = new InstallmentDto
        {
          Principal = capitalInstallment,
          Interest = interest,
          InstallmentDate = DateTime.Now.AddMonths(i)
        };
        response.Installments.Add(installment);
      }

      response.TotalInterest = response.Installments.Sum(x => x.Interest);
      response.TotalPrincipal = response.Installments.Sum(x => x.Principal);
      response.TotalPayment = response.Installments.Sum(x => x.Payment);
      return response;
    }
  }
}