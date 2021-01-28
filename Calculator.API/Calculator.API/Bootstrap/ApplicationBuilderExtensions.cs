using System.Linq;
using Calculator.Core;
using Calculator.Core.Entity;
using Calculator.Dto.Enum;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Calculator.API.Bootstrap
{
  public static class ApplicationBuilderExtensions
  {
    public static IApplicationBuilder SeedData(this IApplicationBuilder builder)
    {
      using (var serviceScope = builder.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
      using (var context = serviceScope.ServiceProvider.GetService<CalculatorDbContext>())
      {
        context.Seed();
      }

      return builder;
    }


  private static void Seed(this CalculatorDbContext context)
    {
      if (!context.LoanType.Any())
      {
        context.LoanType.AddAsync(new LoanType {Id = 1, Name = ELoanType.House.ToString(), Description = "House loan entity", InterestRate = 3.5f});
        context.SaveChanges();
      }

    }
  }
}