using BookDemo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;
using MediatR;
using Microsoft.Extensions.Configuration;
using BookDemo.Adapter.Common.Extensions;

namespace BookDemo.Infrastructure.Database
{
   public class ApplicationDbContext : DbContext
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
         if (Database.CurrentTransaction == null)
         {
            {
               await this.DispatchDomainEventsAsync(_mediator);
            }
         }

         return await base.SaveChangesAsync(cancellationToken);
      }

      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      {
         base.OnConfiguring(optionsBuilder);

         optionsBuilder
            .UseSqlite(_configuration.GetConnectionString("Database"))
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
              entity.ToTable("books");
           })
            .Entity<Author>(entity =>
         {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.FirstName).IsRequired();
            entity.Property(e => e.LastName).IsRequired();
            entity.Property(e => e.CreatedAt).IsRequired();
            entity.Property(e => e.UpdatedAt).IsRequired();
            entity.HasMany(e => e.Books)
                .WithOne(b => b.Author);
            entity.ToTable("authors");
         });
      }
   }
}