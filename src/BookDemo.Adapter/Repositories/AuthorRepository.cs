using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BookDemo.Application.Common.Interfaces;
using BookDemo.Domain.Entities;
using BookDemo.Domain.Repositories;

namespace BookDemo.Adapter.Repositories;

public class AuthorRepository : IAuthorRepository
{
   private readonly IApplicationDbContext _context;

   public AuthorRepository(IApplicationDbContext context)
   {
      _context = context;
   }

   public IQueryable<Author> GetAllAuthors()
   {
      return _context.Authors;
   }

   public void AddAuthor(Author Author)
   {
      _context.Authors.Add(Author);
   }

   public void UpdateAuthor(Author Author)
   {
      _context.Authors.Update(Author);
   }

   public Author? DeleteAuthor(int AuthorId)
   {
      var author = _context.Authors.Find(AuthorId);

      if (author != null)
      {
         _context.Authors.Remove(author);
      }

      return author;
   }

   public void Count()
   {
      _context.Authors.Count();
   }

   public async Task SaveAsync(CancellationToken cancellationToken)
   {
      await _context.SaveChangesAsync(cancellationToken);
   }
}