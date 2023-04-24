using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using BookDemo.Domain.Entities;
using BookDemo.Domain.Repositories;

using MediatR;

namespace BookDemo.Application.Features.Authors.Queries.FindAuthor
{
   public class FindAuthorQueryHandler : IRequestHandler<FindAuthorQuery, IQueryable<Author>>
   {
      private readonly IAuthorRepository _authorRepository;

      public FindAuthorQueryHandler(IAuthorRepository authorRepository)
      {
         _authorRepository = authorRepository;
      }

      public Task<IQueryable<Author>> Handle(FindAuthorQuery request, CancellationToken cancellationToken)
      {
         return Task.FromResult(
            from Author in _authorRepository.GetAll()
            where Author.Id == request.Id
            select Author
         );
      }
   }
}