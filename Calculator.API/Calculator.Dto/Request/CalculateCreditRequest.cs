using Calculator.Dto.Enum;

namespace Calculator.Dto.Request
{
  public class CalculateCreditRequest
  {
    public decimal Value { get; set; }
    public int Period { get; set; }
    public ECreditType Type { get; set; } 
    public EPeriodType PeriodType { get; set; } 
  }
}