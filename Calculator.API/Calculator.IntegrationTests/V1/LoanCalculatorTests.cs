// // <copyright file="LoanCalculatorTests.cs" company="CodePlus Software">
// // Copyright(c) 2021 All Right Reserved
// // </copyright>
// // <author>Szymon Hełmecki</author>
// // <date>26-01-2021</date>
// // <summary>LoanCalculatorTests.cs</summary>

using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Calculator.IntegrationTests.V1
{
  public class LoanCalculatorTests: IClassFixture<CalculatorApplicationFactory>
  {
    private readonly CalculatorApplicationFactory factory;
    private string baseUrl;

    public LoanCalculatorTests(CalculatorApplicationFactory factory)
    {
      this.factory = factory;
      this.baseUrl = "loan/calculator";
    }

    [Fact]
    public async Task Get()
    {
      //Arrange
      var request = this.factory.Server.CreateRequest(this.baseUrl);
      
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