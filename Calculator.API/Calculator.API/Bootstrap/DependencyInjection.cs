// // <copyright file="DependencyInjection.cs" company="CodePlus Software">
// // Copyright(c) 2021 All Right Reserved
// // </copyright>
// // <author>Szymon Hełmecki</author>
// // <date>26-01-2021</date>
// // <summary>DependencyInjection.cs</summary>

using System.Globalization;
using Calculator.Business.Services;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Calculator.API.Bootstrap
{
  public static class DependencyInjection
  {
    public static IServiceCollection RegisterDependencies(this IServiceCollection serviceCollection)
      => serviceCollection
        .RegisterServices()
        .RegisterValidators();

    public static IServiceCollection RegisterServices(this IServiceCollection serviceCollection)
    {
      serviceCollection.AddScoped<ILoanCalculatorService, LoanCalculatorService>();
      return serviceCollection;
    }
    
    public static IServiceCollection RegisterValidators(this IServiceCollection serviceCollection)
    {
      ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("en");
      serviceCollection.AddValidatorsFromAssembly(typeof(LoanCalculatorService).Assembly);
      
      return serviceCollection;
    }
  }
}