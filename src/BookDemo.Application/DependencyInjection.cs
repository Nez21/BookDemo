using System.Reflection;

using BookDemo.Application.Common.Behaviors;

using FluentValidation;

using MediatR;

using Microsoft.Extensions.DependencyInjection;

namespace BookDemo.Application
{
   public static class DependencyInjection
   {
      public static IServiceCollection AddApplication(this IServiceCollection services)
      {
         var assembly = Assembly.GetExecutingAssembly();

         services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
         services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
         services.AddAutoMapper(assembly);
         services.AddValidatorsFromAssembly(assembly);

         return services;
      }
   }
}