using System.Linq;
using BookDemo.Domain.Common.Interfaces;
using BookDemo.Domain.Entities;

namespace BookDemo.Domain.Repositories;

public interface IAuthorRepository : IRepository
{
   IQueryable<Author> GetAllAuthors();
   void AddAuthor(Author author);
   void UpdateAuthor(Author author);
   Author? DeleteAuthor(int authorId);
   void Count();
}