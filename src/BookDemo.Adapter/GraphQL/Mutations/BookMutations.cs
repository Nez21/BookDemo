
using System.Threading;
using System.Threading.Tasks;

using BookDemo.Application.Features.Books.Commands.CreateBook;
using BookDemo.Application.Features.Books.Commands.DeleteBook;
using BookDemo.Application.Features.Books.Commands.UpdateBook;
using BookDemo.Domain.Entities;

using HotChocolate;
using HotChocolate.Types;

using MediatR;

namespace BookDemo.Adapter.GraphQL.Mutations
{
   [ExtendObjectType(OperationTypeNames.Mutation)]
   public class BookMutations
   {
      public async Task<Book> CreateBook(
         CreateBookCommand input,
        [Service] IMediator mediator,
        CancellationToken cancellationToken)
      {
         return await mediator.Send(input, cancellationToken);
      }

      public async Task<Book> UpdateBook(
         UpdateBookCommand input,
         [Service] IMediator mediator,
         CancellationToken cancellationToken)
      {
         return await mediator.Send(input, cancellationToken);
      }

      public async Task<Book> DeleteBook(
         int id,
         [Service] IMediator mediator,
         CancellationToken cancellationToken)
      {
         return await mediator.Send(new DeleteBookCommand { Id = id }, cancellationToken);
      }
   }
}