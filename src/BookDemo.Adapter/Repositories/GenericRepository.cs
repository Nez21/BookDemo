using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using BookDemo.Domain.Common.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace BookDemo.Adapter.Repositories
{
   public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
   {
      private readonly DbContext _context;
      private readonly DbSet<TEntity> _dbSet;
      protected GenericRepository(DbContext context)
      {
         _context = context;
         _dbSet = context.Set<TEntity>();
      }

      public IQueryable<TEntity> GetAll()
      {
         return _dbSet.AsNoTracking();
      }

      public void Add(TEntity entity)
      {
         _dbSet.Add(entity);
      }

      public void Update(TEntity entity)
      {
         _dbSet.Update(entity);
      }

      public TEntity? Delete(TEntity entity)
      {
         return _dbSet.Remove(entity).Entity;
      }

      public int Count()
      {
         return _dbSet.Count();
      }

      public async Task SaveAsync(CancellationToken cancellationToken)
      {
         await _context.SaveChangesAsync(cancellationToken);
      }
   }
}