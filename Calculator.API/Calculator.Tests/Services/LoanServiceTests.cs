using System;
using System.Threading.Tasks;
using Calculator.Business.Exceptions;
using Calculator.Business.Services;
using Calculator.Core;
using Calculator.Core.Entity;
using Calculator.Dto.Enum;
using FluentAssertions;
using Xunit;
using AutoFixture;

namespace Calculator.Tests.Services
{
  public class LoanServiceTests: BaseTestClass
  {
    private readonly ILoanService service;
    private readonly LoanDbContext context;

    public LoanServiceTests()
    {
      this.context = CreateContext();
      this.service = new LoanService(this.context);
    }
    
    [Fact]
    public async Task GetLoanTypeOrFailAsync_ShouldThrowItemNotFoundException_WhenLoanTypeNotFound()
    {
      //Arrange
      ELoanType type = 0;
      
      //Act
      Func<Task> act = () =>  service.GetLoanTypeOrFailAsync(type);

      //Assert
      await act.Should().ThrowAsync<ItemNotFoundException>();
    }
    
    [Fact]
    public async Task GetLoanTypeOrFailAsync_ShouldReturnLoanType_WhenLoanTypeExists()
    {
      //Arrange
      ELoanType type = ELoanType.House;
      var expectedLoanType = Fixture.Build<LoanTypeEntity>()
        .With(x => x.Name, type.ToString)
        .Create();

      await this.context.LoanType.AddAsync(expectedLoanType);
      await this.context.SaveChangesAsync();

      //Act
      var loanType = await  service.GetLoanTypeOrFailAsync(type);

      //Assert
      loanType.Should().Be(expectedLoanType);
    }
  }
}