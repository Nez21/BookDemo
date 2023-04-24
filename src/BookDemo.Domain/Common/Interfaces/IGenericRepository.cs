using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BookDemo.Domain.Common.Interfaces;

public interface IGenericRepository<TEntity> where TEntity : class
{
   IQueryable<TEntity> GetAll();
   void Add(TEntity entity);
   void Update(TEntity entity);
   TEntity? Delete(TEntity entity);
   int Count();
   Task SaveAsync(CancellationToken cancellationToken);
}