using System;
using System.Collections.Generic;
using BookDemo.Domain.Common.Models;

namespace BookDemo.Domain.Entities;

public class Author : BaseEntity
{
   public int Id { get; set; }
   public string FirstName { get; set; } = null!;
   public string LastName { get; set; } = null!;
   public DateTime CreatedAt { get; set; } = new();
   public DateTime UpdatedAt { get; set; }

   public ICollection<Book> Books { get; set; } = Array.Empty<Book>();
}
