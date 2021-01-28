using System.Collections.Generic;
using Calculator.Dto.Dto;

namespace Calculator.Dto.Response
{
  public class LoanCalculationResult
  {
    public decimal TotalPrincipal { get; set; }
    public decimal TotalInterest { get; set; }
    public decimal TotalPayment { get; set; }
    public IEnumerable<InstallmentDto> Installments { get; set; }
  }
}