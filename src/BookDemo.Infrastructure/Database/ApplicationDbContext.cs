using BookDemo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using BookDemo.Application.Common.Interfaces;
using System.Threading.Tasks;
using System.Threading;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace BookDemo.Infrastructure.Database;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
   private readonly IConfiguration _configuration;
   private readonly IMediator _mediator;

   public ApplicationDbContext(DbContextOptions options, IMediator mediator, IConfiguration configuration) : base(options)
   {
      _mediator = mediator;
      _configuration = configuration;
   }

   public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
   {
      if (this.Database.CurrentTransaction == null)
         await _mediator.DispatchDomainEventsAsync(this);

      return await base.SaveChangesAsync(cancellationToken);
   }

   public DbSet<Book> Books => Set<Book>();
   public DbSet<Author> Authors => Set<Author>();

   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
   {
      base.OnConfiguring(optionsBuilder);

      optionsBuilder
         .UseSqlite("Data Source=Database.db")
         .UseSnakeCaseNamingConvention();
   }

   protected override void OnModelCreating(ModelBuilder modelBuilder)
   {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<Book>(entity =>
        {
           entity.HasKey(e => e.Id);
           entity.Property(e => e.Id).ValueGeneratedOnAdd();
           entity.Property(e => e.Title).IsRequired();
           entity.Property(e => e.Genre).IsRequired();
           entity.Property(e => e.Description).IsRequired();
           entity.Property(e => e.CreatedAt).IsRequired();
           entity.Property(e => e.UpdatedAt).IsRequired();
           entity.HasOne(e => e.Author)
               .WithMany(a => a.Books)
               .HasForeignKey(e => e.AuthorId)
               .OnDelete(DeleteBehavior.Cascade);
        });

      modelBuilder.Entity<Author>(entity =>
      {
         entity.HasKey(e => e.Id);
         entity.Property(e => e.Id).ValueGeneratedOnAdd();
         entity.Property(e => e.FirstName).IsRequired();
         entity.Property(e => e.LastName).IsRequired();
         entity.Property(e => e.CreatedAt).IsRequired();
         entity.Property(e => e.UpdatedAt).IsRequired();
         entity.HasMany<Book>(e => e.Books)
             .WithOne(b => b.Author);
      });
   }
}

