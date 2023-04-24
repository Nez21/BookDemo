using System.Linq;
using BookDemo.Domain.Common.Interfaces;
using BookDemo.Domain.Entities;

namespace BookDemo.Domain.Repositories;

public interface IBookRepository : IRepository<Book>
{
}