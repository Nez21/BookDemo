
using System.Threading;
using System.Threading.Tasks;
using BookDemo.Application.Features.Authors.Commands.CreateAuthor;
using BookDemo.Application.Features.Authors.Commands.DeleteAuthor;
using BookDemo.Application.Features.Authors.Commands.UpdateAuthor;
using BookDemo.Domain.Entities;
using HotChocolate;
using HotChocolate.Types;
using MediatR;

namespace BookDemo.Adapter.GraphQL.Mutations;

[ExtendObjectType(OperationTypeNames.Mutation)]
public class AuthorMutations
{
   public async Task<Author> CreateAuthor(
      CreateAuthorCommand input,
     [Service] IMediator mediator,
     CancellationToken cancellationToken)
   {
      return await mediator.Send(input, cancellationToken);
   }

   public async Task<Author> UpdateAuthor(
      UpdateAuthorCommand input,
      [Service] IMediator mediator,
      CancellationToken cancellationToken)
   {
      return await mediator.Send(input, cancellationToken);
   }

   public async Task<Author> DeleteAuthor(
      int id,
      [Service] IMediator mediator,
      CancellationToken cancellationToken)
   {
      return await mediator.Send(new DeleteAuthorCommand { Id = id }, cancellationToken);
   }
}