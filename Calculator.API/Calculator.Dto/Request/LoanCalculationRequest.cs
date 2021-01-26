// // <copyright file="CalculateCreditRequest.cs" company="CodePlus Software">
// // Copyright(c) 2021 All Right Reserved
// // </copyright>
// // <author>Szymon Hełmecki</author>
// // <date>26-01-2021</date>
// // <summary>CalculateCreditRequest.cs</summary>

using Calculator.Dto.Enum;

namespace Calculator.Dto.Request
{
  public class LoanCalculationRequest
  {
    public decimal Amount { get; set; }
    public int Period { get; set; }
    public ELoanType Type { get; set; } 
    public EPeriodType PeriodType { get; set; } 
  }
}