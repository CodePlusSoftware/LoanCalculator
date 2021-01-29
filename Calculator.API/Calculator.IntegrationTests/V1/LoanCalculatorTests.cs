using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Calculator.IntegrationTests.V1
{
  public class LoanCalculatorTests : IClassFixture<CalculatorApplicationFactory>
  {
    private readonly CalculatorApplicationFactory factory;
    private readonly string baseUrl;

    public LoanCalculatorTests(CalculatorApplicationFactory factory)
    {
      this.factory = factory;
      baseUrl = "loan/calculator";
    }

    [Fact]
    public async Task Get()
    {
      //Arrange
      var request = factory.Server.CreateRequest(baseUrl);

      //Act
      var result = await request.GetAsync();

      //Assert
      result.StatusCode.Should().Be(HttpStatusCode.OK);
      var responseString = await result.Content.ReadAsStringAsync();
      responseString.Should().Be("test");
      /*result.Content.Should().Be("test");*/
    }
  }
}