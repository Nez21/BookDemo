using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

using BookDemo.Adapter.Common.Extensions;
using BookDemo.Domain.Common.Interfaces;

using MediatR;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace BookDemo.Adapter.Common.Behaviors
{
   public class UnitOfWork : IUnitOfWork
   {
      private readonly DbContext _context;
      private readonly IMediator _mediator;
      private IDbContextTransaction? _transaction;
      private bool _disposed;

      public UnitOfWork(DbContext context, IMediator mediator, IsolationLevel isolationLevel)
      {
         _context = context;
         _mediator = mediator;
         _context.Database.AutoTransactionBehavior = AutoTransactionBehavior.Never;
         _transaction = _context.Database.BeginTransaction(isolationLevel);
      }

      public async Task<int> CommitAsync(CancellationToken cancellationToken)
      {
         if (_transaction == null)
         {
            throw new DataException("Transaction is closed.");
         }

         try
         {
            var result = await _context.SaveChangesAsync(cancellationToken);
            await _context.DispatchDomainEventsAsync(_mediator);
            await _transaction.CommitAsync(cancellationToken);

            return result;
         }
         finally
         {
            _transaction.Dispose();
            _transaction = null;
         }
      }

      protected virtual void Dispose(bool disposing)
      {
         if (!_disposed)
         {
            if (disposing)
            {
               _context.Dispose();
               _transaction?.Dispose();
               _transaction = null;
            }

            _disposed = true;
         }
      }

      public void Dispose()
      {
         Dispose(true);
         GC.SuppressFinalize(this);
      }
   }
}