using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BookDemo.Infrastructure.Persistence
{
   public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
   {
      public ApplicationDbContext CreateDbContext(string[] args)
      {
         var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

#pragma warning disable 8625
         return new ApplicationDbContext(optionsBuilder.Options, null, null);
      }
   }
}