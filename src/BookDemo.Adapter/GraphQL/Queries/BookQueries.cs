using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BookDemo.Domain.Entities;
using BookDemo.Application.Features.Books.Queries.ListBooks;
using HotChocolate;
using MediatR;
using BookDemo.Application.Features.Books.Queries.FindBook;
using HotChocolate.Types;
using HotChocolate.Data;

namespace BookDemo.Adapter.GraphQL.Queries;


[ExtendObjectType(OperationTypeNames.Query)]
public class BookQueries
{
   [UseOffsetPaging(IncludeTotalCount = true)]
   [UseProjection]
   [UseFiltering]
   [UseSorting]
   public async Task<IQueryable<Book>> ListBooks(
     [Service] IMediator mediator,
     CancellationToken cancellationToken)
   {
      return await mediator.Send(new ListBooksQuery(), cancellationToken);
   }

   [UseFirstOrDefault]
   [UseProjection]
   [UseFiltering]
   [UseSorting]
   public async Task<IQueryable<Book>> FindBook(FindBookQuery input, [Service] IMediator mediator, CancellationToken cancellationToken)
   {
      return await mediator.Send(input, cancellationToken);
   }
}