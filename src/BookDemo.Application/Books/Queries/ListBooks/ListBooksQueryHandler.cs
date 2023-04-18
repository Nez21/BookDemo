using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BookDemo.Domain.Entities;
using BookDemo.Domain.Repositories;
using MediatR;

namespace BookDemo.Application.Books.Queries.ListBooks;

public class ListBooksQueryHandler : IRequestHandler<ListBooksQuery, IQueryable<Book>>
{
   private readonly IBookRepository _bookRepository;

   public ListBooksQueryHandler(IBookRepository bookRepository)
   {
      _bookRepository = bookRepository;
   }

   public Task<IQueryable<Book>> Handle(ListBooksQuery request, CancellationToken cancellationToken)
   {
      return Task.FromResult(_bookRepository.GetAllBooks());
   }
}