using System;
using BookDemo.Domain.Common;
using BookDemo.Domain.Common.Models;

namespace BookDemo.Domain.Entities;

public class Book : BaseEntity
{
   public int Id { get; set; }
   public int AuthorId { get; set; }
   public string Title { get; set; } = null!;
   public string Genre { get; set; } = null!;
   public string Description { get; set; } = null!;
   public DateTime CreatedAt { get; set; } = new();
   public DateTime UpdatedAt { get; set; }

   public Author Author { get; set; } = null!;
}