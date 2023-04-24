using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using BookDemo.Domain.Entities;
using BookDemo.Domain.Repositories;

using MediatR;

namespace BookDemo.Application.Features.Books.Queries.FindBook
{
   public class FindBookQueryHandler : IRequestHandler<FindBookQuery, IQueryable<Book>>
   {
      private readonly IBookRepository _bookRepository;

      public FindBookQueryHandler(IBookRepository bookRepository)
      {
         _bookRepository = bookRepository;
      }

      public Task<IQueryable<Book>> Handle(FindBookQuery request, CancellationToken cancellationToken)
      {
         return Task.FromResult(
            from book in _bookRepository.GetAll()
            where book.Id == request.Id
            select book
         );
      }
   }
}