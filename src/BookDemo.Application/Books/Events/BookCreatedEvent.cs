using BookDemo.Domain.Common;
using BookDemo.Domain.Common.Models;
using BookDemo.Domain.Entities;

namespace BookDemo.Application.Books.Events;

public class BookCreatedEvent : BaseEvent
{
   public Book Book { get; set; } = null!;
}