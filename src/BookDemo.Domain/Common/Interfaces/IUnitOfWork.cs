using System;
using System.Threading;
using System.Threading.Tasks;

namespace BookDemo.Domain.Common.Interfaces;

public interface IUnitOfWork : IDisposable
{
   Task<int> CommitAsync(CancellationToken cancellationToken = default);

}