using MediatR;
using BookDemo.Domain.Entities;
using AutoMapper;
using FluentValidation;

namespace BookDemo.Application.Features.Books.Commands.CreateBook
{
   public class CreateBookCommand : IRequest<Book>
   {
      public int AuthorId { get; set; }
      public string Title { get; set; } = null!;
      public string Genre { get; set; } = null!;
      public string Description { get; set; } = null!;
   }
   public class CreateBookCommandProfile : Profile
   {
      public CreateBookCommandProfile()
      {
         CreateMap<CreateBookCommand, Book>();
      }
   }

   public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
   {
      public CreateBookCommandValidator()
      {
         RuleFor(v => v.AuthorId).Must(v => v >= 0).WithMessage("AuthorId must be non-negative number");
         RuleFor(v => v.Title).NotEmpty().MaximumLength(200).WithMessage("Title must not be empty and must be less than 200 characters");
         RuleFor(v => v.Genre).NotEmpty().MaximumLength(50).WithMessage("Genre must not be empty and must be less than 50 characters");
         RuleFor(v => v.Description).MaximumLength(500).WithMessage("Description must be less than 500 characters");
      }
   }
}