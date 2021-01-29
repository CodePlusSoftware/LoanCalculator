
using System.Threading.Tasks;
using Xunit;

namespace Calculator.IntegrationTests.Fixtures
{
  public class DatabaseFixture: IClassFixture<CalculatorApplicationFactory>, IAsyncLifetime
  {
    private readonly CalculatorApplicationFactory factory;

    public DatabaseFixture(CalculatorApplicationFactory factory)
    {
      this.factory = factory;
    }

    public Task InitializeAsync()
    {
      throw new System.NotImplementedException();
    }

    public Task DisposeAsync()
    {
      throw new System.NotImplementedException();
    }
  }
}