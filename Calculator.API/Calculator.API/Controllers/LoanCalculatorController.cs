// // <copyright file="LoanCalculatorController.cs" company="CodePlus Software">
// // Copyright(c) 2021 All Right Reserved
// // </copyright>
// // <author>Szymon Hełmecki</author>
// // <date>26-01-2021</date>
// // <summary>LoanCalculatorController.cs</summary>

using System.Threading.Tasks;
using Calculator.Business.Services;
using Calculator.Dto.Request;
using Calculator.Dto.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Calculator.API.Controllers
{
  [Route("loan/calculator")]
  public class CreditCalculatorController: ControllerBase
  {
    private readonly ILoanCalculatorManager loanCalculatorManager;

    public CreditCalculatorController(ILoanCalculatorManager loanCalculatorManager)
    {
      this.loanCalculatorManager = loanCalculatorManager;
    }

    [HttpGet]
    [ProducesResponseType(typeof(LoanCalculationResult), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Calculate(CalculateLoanRequest request)
    {
      var result = await this.loanCalculatorManager.CalculateAsync(request);
      return Ok(result);
    }
  }
}