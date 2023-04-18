using BookDemo.Adapter;
using BookDemo.Application;
using BookDemo.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

internal class Program
{
   private static void Main(string[] args)
   {
      var builder = WebApplication.CreateBuilder(args);

      builder.Services.AddInfrastructure(builder.Configuration);
      builder.Services.AddAdapter();
      builder.Services.AddApplication();

      var app = builder.Build();

      app.MapGraphQL();
      app.Run();
   }
}