using System.Linq;
using System.Threading.Tasks;

using BookDemo.Domain.Common.Models;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace BookDemo.Adapter.Common.Extensions
{
   public static class DbContextExtensions
   {
      public static async Task DispatchDomainEventsAsync(this DbContext context, IMediator mediator)
      {
         var domainEntities = context.ChangeTracker
            .Entries<BaseEntity>()
            .Where(x => x.Entity.DomainEvents?.Any() == true);

         var domainEvents = domainEntities
            .SelectMany(x => x.Entity.DomainEvents)
            .ToList();

         domainEntities.ToList()
            .ForEach(entity => entity.Entity.DomainEvents.Clear());

         var tasks = domainEvents
            .Select(async (domainEvent) =>
               await mediator.Publish(domainEvent)
            );

         await Task.WhenAll(tasks);
      }
   }
}