using BookDemo.Domain.Entities;
using BookDemo.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookDemo.Adapter.Repositories;

public class BookRepository : GenericRepository<Book>, IBookRepository
{

   public BookRepository(DbContext context) : base(context)
   {
   }
}