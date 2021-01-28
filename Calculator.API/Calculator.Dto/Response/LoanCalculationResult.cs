// // <copyright file="LoanCalculationResponse.cs" company="CodePlus Software">
// // Copyright(c) 2021 All Right Reserved
// // </copyright>
// // <author>Szymon Hełmecki</author>
// // <date>26-01-2021</date>
// // <summary>LoanCalculationResponse.cs</summary>


using System.Collections.Generic;
using Calculator.Dto.Dto;

namespace Calculator.Dto.Response
{
  public class LoanCalculationResult
  {
    public LoanCalculationResult()
    {
      this.Installments = new List<InstallmentDto>();
    }

    public decimal TotalPrincipal { get; set; }
    public decimal TotalInterest { get; set; }
    public decimal TotalPayment { get; set; }
    public List<InstallmentDto> Installments { get; }
  }
}