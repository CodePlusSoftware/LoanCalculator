// // <copyright file="LoanCalculatorService.cs" company="CodePlus Software">
// // Copyright(c) 2021 All Right Reserved
// // </copyright>
// // <author>Szymon Hełmecki</author>
// // <date>26-01-2021</date>
// // <summary>LoanCalculatorService.cs</summary>

using System.Threading.Tasks;
using Calculator.Dto.Request;
using Calculator.Dto.Response;

namespace Calculator.Business.Services
{
  public class LoanCalculatorService : ILoanCalculatorService
  {
    public async Task<LoanCalculationResponse> Calculate(LoanCalculationRequest request)
    {
      return null;
    }
  }
}