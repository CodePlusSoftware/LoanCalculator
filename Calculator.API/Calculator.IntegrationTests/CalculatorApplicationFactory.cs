using System.IO;
using Calculator.API;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Calculator.IntegrationTests
{
  public class CalculatorApplicationFactory : WebApplicationFactory<Startup>
  {
    protected override IHostBuilder CreateHostBuilder()
    {
      var configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .AddEnvironmentVariables()
        .Build();
      
      return Host.CreateDefaultBuilder().ConfigureWebHostDefaults(builder =>
        builder.UseStartup<Startup>().UseTestServer())
        .UseSerilog((host, logger) => { logger.ReadFrom.Configuration(configuration); });
    }
  }
}