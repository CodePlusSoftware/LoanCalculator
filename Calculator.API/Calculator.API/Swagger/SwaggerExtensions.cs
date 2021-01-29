using Calculator.API.Bootstrap;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Calculator.API.Swagger
{
  public static class SwaggerExtensions
  {
    /// <summary>
    ///   The add swagger docs.
    /// </summary>
    /// <param name="services">
    ///   The services.
    /// </param>
    /// <returns>
    ///   The <see cref="IServiceCollection" />.
    /// </returns>
    public static IServiceCollection AddSwaggerDocs(this IServiceCollection services)
    {
      SwaggerOptions options;
      using (var serviceProvider = services.BuildServiceProvider())
      {
        var configuration = serviceProvider.GetService<IConfiguration>();
        services.Configure<SwaggerOptions>(configuration.GetSection("swagger"));
        options = configuration.GetOptions<SwaggerOptions>("swagger");
      }

      if (!options.Enabled) return services;

      return services.AddSwaggerGen(
        c => { c.SwaggerDoc(options.Name, new OpenApiInfo {Title = options.Title, Version = options.Version}); });
    }

    /// <summary>
    ///   The use swagger docs.
    /// </summary>
    /// <param name="builder">
    ///   The builder.
    /// </param>
    /// <returns>
    ///   The <see cref="IApplicationBuilder" />.
    /// </returns>
    public static IApplicationBuilder UseSwaggerDocs(this IApplicationBuilder builder)
    {
      var options = builder.ApplicationServices.GetService<IConfiguration>().GetOptions<SwaggerOptions>("swagger");
      if (!options.Enabled) return builder;

      var routePrefix = string.IsNullOrWhiteSpace(options.RoutePrefix) ? "swagger" : options.RoutePrefix;

      builder.UseStaticFiles().UseSwagger(c => c.RouteTemplate = routePrefix + "/{documentName}/swagger.json");

      return builder.UseSwaggerUI(
        c =>
        {
          c.SwaggerEndpoint($"/{routePrefix}/{options.Name}/swagger.json", options.Title);
          c.RoutePrefix = routePrefix;
          if (options.Enabled)
          {
            c.OAuthClientId("tutory-swagger");
            c.OAuthAppName("Tutory API - Swagger");
          }
        });
    }
  }
}