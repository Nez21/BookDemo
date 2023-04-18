using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using HotChocolate;

namespace BookDemo.Domain.Common.Models;

public abstract class BaseEntity
{
   private readonly List<BaseEvent> _domainEvents = new();

   [NotMapped]
   [GraphQLIgnore]
   public IReadOnlyCollection<BaseEvent> DomainEvents => _domainEvents.AsReadOnly();

   public void AddDomainEvent(BaseEvent domainEvent)
   {
      _domainEvents.Add(domainEvent);
   }

   public void RemoveDomainEvent(BaseEvent domainEvent)
   {
      _domainEvents.Remove(domainEvent);
   }

   public void ClearDomainEvents()
   {
      _domainEvents.Clear();
   }
}