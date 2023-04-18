using System.Linq;
using BookDemo.Domain.Common.Interfaces;
using BookDemo.Domain.Entities;

namespace BookDemo.Domain.Repositories;

public interface IBookRepository : IRepository
{
   IQueryable<Book> GetAllBooks();
   void AddBook(Book book);
   void UpdateBook(Book book);
   Book? DeleteBook(int bookId);
   void Count();
}