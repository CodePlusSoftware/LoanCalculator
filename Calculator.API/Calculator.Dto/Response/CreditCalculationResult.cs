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
  public class CreditCalculationResult
  {
    public CreditCalculationResult()
    {
      this.Installments = new List<InstallmentDto>();
    }

    public decimal TotalCapital { get; set; }
    public decimal TotalInterest { get; set; }
    public decimal TotalInstallment { get; set; }
    public List<InstallmentDto> Installments { get; }
  }
}