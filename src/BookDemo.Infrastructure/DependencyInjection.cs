using BookDemo.Application.Common.Interfaces;
using BookDemo.Domain.Common.Interfaces;
using BookDemo.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookDemo.Infrastructure;

public static class DependencyInjection
{

   public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
   {
      services.AddScoped<AddTimestampInterceptor>();
      services.AddDbContext<ApplicationDbContext>((provider, options) =>
         options
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
            .AddInterceptors(provider.GetRequiredService<AddTimestampInterceptor>()));
      services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
      services.AddLogging();

      return services;
   }
}