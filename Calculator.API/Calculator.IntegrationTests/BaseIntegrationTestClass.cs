using AutoFixture;
using Xunit;

namespace Calculator.IntegrationTests
{
  public class BaseIntegrationTestClass: IClassFixture<CalculatorApplicationFactory>
  {
    protected CalculatorApplicationFactory Factory;
    protected Fixture Fixture { get; }

    public BaseIntegrationTestClass(CalculatorApplicationFactory factory)
    {
      this.Factory = factory;
      this.Fixture = new Fixture();
    }
  }
}