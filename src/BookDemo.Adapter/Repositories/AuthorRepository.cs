using BookDemo.Domain.Entities;
using BookDemo.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookDemo.Adapter.Repositories;

public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
{

   public AuthorRepository(DbContext context) : base(context)
   {
   }
}