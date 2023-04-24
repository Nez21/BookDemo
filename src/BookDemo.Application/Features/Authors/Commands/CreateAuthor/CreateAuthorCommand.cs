using MediatR;
using BookDemo.Domain.Entities;
using AutoMapper;
using FluentValidation;

namespace BookDemo.Application.Features.Authors.Commands.CreateAuthor
{
   public class CreateAuthorCommand : IRequest<Author>
   {
      public string FirstName { get; set; } = null!;
      public string LastName { get; set; } = null!;
   }

   public class CreateAuthorCommandProfile : Profile
   {
      public CreateAuthorCommandProfile()
      {
         CreateMap<CreateAuthorCommand, Author>();
      }
   }

   public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
   {
      public CreateAuthorCommandValidator()
      {
         RuleFor(v => v.FirstName).NotEmpty().MaximumLength(50).WithMessage("FirstName must not be empty and must be less than 50 characters");
         RuleFor(v => v.LastName).NotEmpty().MaximumLength(50).WithMessage("LastName must not be empty and must be less than 50 characters");
      }
   }
}