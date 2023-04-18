using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BookDemo.Application.Common.Interfaces;
using BookDemo.Domain.Entities;
using BookDemo.Domain.Repositories;

namespace BookDemo.Adapter.Repositories;

public class BookRepository : IBookRepository
{
   private readonly IApplicationDbContext _context;

   public BookRepository(IApplicationDbContext context)
   {
      _context = context;
   }

   public IQueryable<Book> GetAllBooks()
   {
      return _context.Books;
   }

   public void AddBook(Book book)
   {
      _context.Books.Add(book);
   }

   public void UpdateBook(Book book)
   {
      _context.Books.Update(book);
   }

   public Book? DeleteBook(int bookId)
   {
      var book = _context.Books.Find(bookId);

      if (book != null)
      {
         _context.Books.Remove(book);
      }

      return book;
   }

   public void Count()
   {
      _context.Books.Count();
   }

   public async Task SaveAsync(CancellationToken cancellationToken)
   {
      await _context.SaveChangesAsync(cancellationToken);
   }
}