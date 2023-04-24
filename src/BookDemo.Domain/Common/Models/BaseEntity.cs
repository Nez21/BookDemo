using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

using HotChocolate;

namespace BookDemo.Domain.Common.Models
{
   public abstract class BaseEntity
   {
      [NotMapped]
      [GraphQLIgnore]
      public ICollection<BaseEvent> DomainEvents { get; init; } = new List<BaseEvent>();
   }
}