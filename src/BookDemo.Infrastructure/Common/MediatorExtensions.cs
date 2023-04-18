using System.Linq;
using System.Threading.Tasks;
using BookDemo.Domain.Common;
using BookDemo.Domain.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace MediatR;

public static class MediatorExtensions
{
   public static async Task DispatchDomainEventsAsync(this IMediator mediator, DbContext context)
   {
      var domainEntities = context.ChangeTracker
         .Entries<BaseEntity>()
         .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any());

      var domainEvents = domainEntities
         .SelectMany(x => x.Entity.DomainEvents)
         .ToList();

      domainEntities.ToList()
         .ForEach(entity => entity.Entity.ClearDomainEvents());

      var tasks = domainEvents
         .Select(async (domainEvent) =>
            await mediator.Publish(domainEvent)
         );

      await Task.WhenAll(tasks);
   }
}