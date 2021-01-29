using System.IO;
using Calculator.API;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;

namespace Calculator.IntegrationTests
{
  public class CalculatorApplicationFactory: WebApplicationFactory<Startup>
  {
    protected override IHostBuilder CreateHostBuilder()
    {
      var builder = Host.CreateDefaultBuilder()
        .ConfigureWebHostDefaults(x =>
        {
          x.UseStartup<Startup>()
            .UseTestServer();
        });
      return builder;
    }
    
    protected override IHost CreateHost(IHostBuilder builder)
    {
      builder.UseContentRoot(Directory.GetCurrentDirectory());
      return base.CreateHost(builder);
    }
  }
}