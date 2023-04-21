using System.Data;
using BookDemo.Domain.Common.Interfaces;
using BookDemo.Infrastructure.Database;
using MediatR;

public class UnitOfWorkFactory : IUnitOfWorkFactory
{
   private readonly ApplicationDbContext _context;
   private readonly IMediator _mediator;

   public UnitOfWorkFactory(ApplicationDbContext context, IMediator mediator)
   {
      _context = context;
      _mediator = mediator;
   }

   public IUnitOfWork Create(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
   {
      return new UnitOfWork(_context, _mediator, isolationLevel);
   }
}
