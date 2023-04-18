using System.Threading;
using System.Threading.Tasks;

namespace BookDemo.Domain.Common.Interfaces;

public interface IRepository
{
   Task SaveAsync(CancellationToken cancellationToken);
}