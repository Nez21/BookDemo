using MediatR;
using BookDemo.Domain.Entities;
using System.Linq;

namespace BookDemo.Application.Features.Authors.Queries.FindAuthor
{
   public class FindAuthorQuery : IRequest<IQueryable<Author>>
   {
      public int Id { get; set; }
   }
}