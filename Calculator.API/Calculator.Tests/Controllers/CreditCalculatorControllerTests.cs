// // <copyright file="LoanCalculatorControllerTests.cs" company="CodePlus Software">
// // Copyright(c) 2021 All Right Reserved
// // </copyright>
// // <author>Szymon Hełmecki</author>
// // <date>26-01-2021</date>
// // <summary>LoanCalculatorControllerTests.cs</summary>

using System.Threading.Tasks;
using Calculator.API.Controllers;
using Calculator.Business.Services;
using Calculator.Dto.Request;
using Moq;
using Xunit;
using AutoFixture;
using Calculator.Dto.Response;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace Calculator.Tests.Controllers
{
  public class CreditCalculatorControllerTests: BaseCalculatorTests
  {
    private readonly Mock<ILoanCalculatorService> loanCalculatorServiceMock;
    private readonly CreditCalculatorController controller;
    public CreditCalculatorControllerTests()
    {
      this.loanCalculatorServiceMock = new Mock<ILoanCalculatorService>();
      this.controller = new CreditCalculatorController(this.loanCalculatorServiceMock.Object);
    }

    [Fact]
    public async Task Calculate_ShouldCallCalculatorService()
    {
      //Arrange
      var request = Fixture.Create<CalculateCreditRequest>();
      
      //Act
      _ = await controller.Calculate(request);

      //Assert
      loanCalculatorServiceMock.Verify(x => x.CalculateAsync(request), Times.Once);
    }
    
    [Fact]
    public async Task Calculate_ShouldReturnCalculatedResult()
    {
      //Arrange
      var request = Fixture.Create<CalculateCreditRequest>();
      var expectedResponse = Fixture.Create<LoanCalculationResult>();
      loanCalculatorServiceMock.Setup(x => x.CalculateAsync(request)).ReturnsAsync(expectedResponse);
      
      //Act
      var response = await controller.Calculate(request);
      
      //Assert
      var okObjectResult = (OkObjectResult) response;
      okObjectResult.Should().NotBeNull();
      okObjectResult.Value.Should().Be(expectedResponse);
    }
  }
}