// // <copyright file="ILoanCalculatorService.cs" company="CodePlus Software">
// // Copyright(c) 2021 All Right Reserved
// // </copyright>
// // <author>Szymon Hełmecki</author>
// // <date>26-01-2021</date>
// // <summary>ILoanCalculatorService.cs</summary>

using System.Threading.Tasks;
using Calculator.Dto.Request;
using Calculator.Dto.Response;

namespace Calculator.Business.Services
{
  public interface ICreditCalculatorService
  {
    Task<CreditCalculationResult> CalculateAsync(CalculateCreditRequest request);
  }
}