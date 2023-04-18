using System.Linq;
using MediatR;
using BookDemo.Domain.Entities;

namespace BookDemo.Application.Books.Queries.FindBook;

public class FindBookQuery : IRequest<IQueryable<Book>>
{
   public int Id { get; set; }
}

