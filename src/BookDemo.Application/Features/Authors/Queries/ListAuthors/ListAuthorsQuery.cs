using System.Linq;
using BookDemo.Domain.Entities;
using MediatR;

namespace BookDemo.Application.Features.Authors.Queries.ListAuthors;

public class ListAuthorsQuery : IRequest<IQueryable<Author>>
{
}

