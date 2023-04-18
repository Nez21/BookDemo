using System;
using System.Threading;
using System.Threading.Tasks;
using BookDemo.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookDemo.Application.Common.Interfaces;

public interface IApplicationDbContext : IDisposable
{
   public DbSet<Book> Books { get; }
   public DbSet<Author> Authors { get; }

   Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}

