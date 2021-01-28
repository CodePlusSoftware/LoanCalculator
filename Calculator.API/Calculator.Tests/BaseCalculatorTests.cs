using AutoFixture;

namespace Calculator.Tests
{
  public class BaseCalculatorTests
  {
    public Fixture Fixture { get; }

    public BaseCalculatorTests()
    {
      this.Fixture = new Fixture();
    }
  }
}