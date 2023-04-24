using BookDemo.Adapter.Common.Behaviors;
using BookDemo.Adapter.GraphQL;
using BookDemo.Adapter.GraphQL.Mutations;
using BookDemo.Adapter.GraphQL.Queries;
using BookDemo.Adapter.Repositories;
using BookDemo.Domain.Common.Interfaces;
using BookDemo.Domain.Repositories;

using Microsoft.Extensions.DependencyInjection;

namespace BookDemo.Adapter
{
   public static class DependencyInjection
   {
      public static IServiceCollection AddAdapter(this IServiceCollection services)
      {
         services
            .AddGraphQLServer()
            .AddQueryType()
            .AddMutationType()
            .AddTypeExtension<AuthorQueries>()
            .AddTypeExtension<BookQueries>()
            .AddTypeExtension<AuthorMutations>()
            .AddTypeExtension<BookMutations>()
            .AddProjections()
            .AddFiltering()
            .AddSorting()
            .AddErrorFilter<ErrorFilter>();

         services.AddScoped<IBookRepository, BookRepository>();
         services.AddScoped<IAuthorRepository, AuthorRepository>();
         services.AddScoped<IUnitOfWorkFactory, UnitOfWorkFactory>();

         return services;
      }
   }
}