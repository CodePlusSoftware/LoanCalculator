using System;

namespace Calculator.Dto.Dto
{
  public class InstallmentDto
  {
    public decimal Principal { get; set; }
    public decimal Interest { get; set; }
    public DateTime InstallmentDate { get; set; }
    public decimal Payment { get; set; }
  }
}