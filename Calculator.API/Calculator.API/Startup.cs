using System.Text.Json.Serialization;
using Calculator.API.Bootstrap;
using Calculator.API.ExceptionHandler;
using Calculator.API.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Calculator.API
{
  public class Startup
  {
    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddControllers()
        .AddJsonOptions(opt => opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
      
      services
        .RegisterDependencies()
        .AddCors(opt => opt.AddPolicy("Test", cors => cors.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()))
        .AddSwaggerDocs();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      app.UseRouting()
        .UseSwaggerDocs()
        .UseCors("Test")
        .UseExceptionHandler(err => err.UseCustomErrors(env))
        .SeedData()
        .UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
  }
}