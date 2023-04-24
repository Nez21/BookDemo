using System.Data;
using BookDemo.Domain.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookDemo.Adapter.Common.Behaviors;

public class UnitOfWorkFactory : IUnitOfWorkFactory
{
   private readonly DbContext _context;
   private readonly IMediator _mediator;

   public UnitOfWorkFactory(DbContext context, IMediator mediator)
   {
      _context = context;
      _mediator = mediator;
   }

   public IUnitOfWork Create(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
   {
      return new UnitOfWork(_context, _mediator, isolationLevel);
   }
}
