using Calculator.Dto.Enum;

namespace Calculator.Dto.Request
{
  public class CalculateLoanRequest
  {
    public decimal Value { get; set; }
    public int Period { get; set; }
    public ELoanType Type { get; set; }
    public EPeriodType PeriodType { get; set; }
    public EPaybackPlan PaybackPlan { get; set; }
  }
}