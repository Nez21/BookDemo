using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BookDemo.Domain.Entities;
using BookDemo.Application.Features.Authors.Queries.ListAuthors;
using HotChocolate;
using MediatR;
using BookDemo.Application.Features.Authors.Queries.FindAuthor;
using HotChocolate.Types;
using HotChocolate.Data;

namespace BookDemo.Adapter.GraphQL.Queries
{
   [ExtendObjectType(OperationTypeNames.Query)]
   public class AuthorQueries
   {
      [UseOffsetPaging(IncludeTotalCount = true)]
      [UseProjection]
      [UseFiltering]
      [UseSorting]
      public async Task<IQueryable<Author>> ListAuthors(
        [Service] IMediator mediator,
        CancellationToken cancellationToken)
      {
         return await mediator.Send(new ListAuthorsQuery(), cancellationToken);
      }

      [UseFirstOrDefault]
      [UseProjection]
      [UseFiltering]
      [UseSorting]
      public async Task<IQueryable<Author>> FindAuthor(FindAuthorQuery input, [Service] IMediator mediator, CancellationToken cancellationToken)
      {
         return await mediator.Send(input, cancellationToken);
      }
   }
}