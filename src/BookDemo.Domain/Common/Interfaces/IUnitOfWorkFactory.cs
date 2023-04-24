using System.Data;

namespace BookDemo.Domain.Common.Interfaces
{
   public interface IUnitOfWorkFactory
   {
      IUnitOfWork Create(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
   }
}