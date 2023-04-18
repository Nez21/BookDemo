using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using BookDemo.Domain.Common.Interfaces;
using BookDemo.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

public class UnitOfWorkFactory : IUnitOfWorkFactory
{
   private readonly ApplicationDbContext _context;

   public UnitOfWorkFactory(ApplicationDbContext context)
   {
      _context = context;
   }

   public IUnitOfWork Create(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
   {
      return new UnitOfWork(_context, isolationLevel);
   }
}
