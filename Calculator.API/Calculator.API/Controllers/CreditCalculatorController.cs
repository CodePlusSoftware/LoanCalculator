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
  [Route("credit/calculator")]
  public class CreditCalculatorController: ControllerBase
  {
    private readonly ICreditCalculatorService creditCalculatorService;

    public CreditCalculatorController(ICreditCalculatorService creditCalculatorService)
    {
      this.creditCalculatorService = creditCalculatorService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(CreditCalculationResult), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Calculate(CalculateCreditRequest request)
    {
      var result = await this.creditCalculatorService.CalculateAsync(request);
      return Ok(result);
    }
  }
}