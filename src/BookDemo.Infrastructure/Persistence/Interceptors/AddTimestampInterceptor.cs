using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

using BookDemo.Domain.Common.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace BookDemo.Infrastructure.Persistence.Interceptors
{
   public class AddTimestampInterceptor : SaveChangesInterceptor
   {
      public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
      {
         UpdateEntities(eventData.Context);

         return base.SavingChanges(eventData, result);
      }

      public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
      {
         UpdateEntities(eventData.Context);

         return base.SavingChangesAsync(eventData, result, cancellationToken);
      }

      public void UpdateEntities(DbContext? context)
      {
         if (context == null)
         {
            return;
         }

         foreach (var entry in context.ChangeTracker.Entries<BaseEntity>())
         {
            var now = DateTime.UtcNow;

            var propInfos = entry.Entity.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
            var createdAt = Array.Find(propInfos, p => p.Name == "CreatedAt");
            var updatedAt = Array.Find(propInfos, p => p.Name == "UpdatedAt");

            if (entry.State == EntityState.Added && createdAt != null)
            {
               createdAt.SetValue(entry.Entity, now);
            }

            updatedAt?.SetValue(entry.Entity, now);
         }
      }
   }
}