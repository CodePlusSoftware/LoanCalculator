using System;

namespace Calculator.Business.Models
{
  public class Installment
  {
    public decimal Principal { get; set; }
    public decimal Interest { get; set; }
    public DateTime InstallmentDate { get; set; }
    public decimal Payment => Principal + Interest;
  }
}