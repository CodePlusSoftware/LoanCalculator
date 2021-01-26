// // <copyright file="LoanCalculatorController.cs" company="CodePlus Software">
// // Copyright(c) 2021 All Right Reserved
// // </copyright>
// // <author>Szymon Hełmecki</author>
// // <date>26-01-2021</date>
// // <summary>LoanCalculatorController.cs</summary>

using System.Threading.Tasks;
using Calculator.Business.Services;
using Calculator.Dto.Request;
using Microsoft.AspNetCore.Mvc;

namespace Calculator.API.Controllers
{
  [Route("loan/calculator")]
  public class LoanCalculatorController: ControllerBase
  {
    private readonly ILoanCalculatorService loanCalculatorService;

    public LoanCalculatorController(ILoanCalculatorService loanCalculatorService)
    {
      this.loanCalculatorService = loanCalculatorService;
    }

    [HttpGet]
    public async Task<IActionResult> Calculate(LoanCalculationRequest request)
    {
      var result = await this.loanCalculatorService.Calculate(request);
      return Ok(result);
    }
  }
}