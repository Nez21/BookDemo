using MediatR;
using BookDemo.Domain.Entities;
using FluentValidation;

namespace BookDemo.Application.Features.Books.Commands.DeleteBook
{
   public class DeleteBookCommand : IRequest<Book>
   {
      public int Id { get; set; }
   }

   public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
   {
      public DeleteBookCommandValidator()
      {
         RuleFor(v => v.Id).Must(v => v >= 0).WithMessage("Id must be non-negative number");
      }
   }
}