using System;
using System.Threading;
using System.Threading.Tasks;

using BookDemo.Domain.Events;

using MediatR;

namespace BookDemo.Application.Features.Books.EventHandlers
{
   public class BookCreatedEventHandler : INotificationHandler<BookCreatedEvent>
   {
      public Task Handle(BookCreatedEvent notification, CancellationToken cancellationToken)
      {
         Console.WriteLine($"Book \"{notification.Book.Title}\" created!");

         return Task.CompletedTask;
      }
   }
}