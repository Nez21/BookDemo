using System;
using System.Reflection;
using BookDemo.Application.Common.Behaviors;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BookDemo.Application;

public static class DependencyInjection
{
   public static IServiceCollection AddApplication(this IServiceCollection services)
   {
      services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
      services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
      services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
      services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

      return services;
   }
}