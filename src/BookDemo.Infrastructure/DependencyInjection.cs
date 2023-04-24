using BookDemo.Infrastructure.Persistence;
using BookDemo.Infrastructure.Persistence.Interceptors;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BookDemo.Infrastructure
{
   public static class DependencyInjection
   {
      public static IServiceCollection AddInfrastructure(this IServiceCollection services)
      {
         services.AddScoped<AddTimestampInterceptor>();
         services.AddDbContext<ApplicationDbContext>((provider, options) =>
            options
               .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
               .AddInterceptors(provider.GetRequiredService<AddTimestampInterceptor>()));
         services.AddScoped<DbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
         services.AddLogging();

         return services;
      }
   }
}