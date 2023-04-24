using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using BookDemo.Domain.Entities;
using BookDemo.Domain.Repositories;

using MediatR;

namespace BookDemo.Application.Features.Authors.Queries.ListAuthors
{
   public class ListAuthorsQueryHandler : IRequestHandler<ListAuthorsQuery, IQueryable<Author>>
   {
      private readonly IAuthorRepository _authorRepository;

      public ListAuthorsQueryHandler(IAuthorRepository authorRepository)
      {
         _authorRepository = authorRepository;
      }

      public Task<IQueryable<Author>> Handle(ListAuthorsQuery request, CancellationToken cancellationToken)
      {
         return Task.FromResult(_authorRepository.GetAll());
      }
   }
}