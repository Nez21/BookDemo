using System.Linq;
using MediatR;
using BookDemo.Domain.Entities;

namespace BookDemo.Application.Features.Books.Queries.ListBooks
{
   public class ListBooksQuery : IRequest<IQueryable<Book>>
   {
   }
}