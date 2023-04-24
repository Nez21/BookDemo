using MediatR;
using BookDemo.Domain.Entities;
using AutoMapper;
using FluentValidation;

namespace BookDemo.Application.Features.Authors.Commands.UpdateAuthor
{
   public class UpdateAuthorCommand : IRequest<Author>
   {
      public int Id { get; set; }
      public string FirstName { get; set; } = null!;
      public string LastName { get; set; } = null!;
   }
   public class UpdateAuthorCommandProfile : Profile
   {
      public UpdateAuthorCommandProfile()
      {
         CreateMap<UpdateAuthorCommand, Author>();
      }
   }

   public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
   {
      public UpdateAuthorCommandValidator()
      {
         RuleFor(v => v.Id).Must(v => v >= 0).WithMessage("Id must be non-negative number");
         RuleFor(v => v.FirstName).NotEmpty().MaximumLength(50).WithMessage("FirstName must not be empty and must be less than 50 characters");
         RuleFor(v => v.LastName).NotEmpty().MaximumLength(50).WithMessage("LastName must not be empty and must be less than 50 characters");
      }
   }
}