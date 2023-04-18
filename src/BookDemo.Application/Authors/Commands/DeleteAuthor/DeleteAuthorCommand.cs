using MediatR;
using BookDemo.Domain.Entities;
using FluentValidation;

namespace BookDemo.Application.Authors.Commands.DeleteAuthor;

public class DeleteAuthorCommand : IRequest<Author>
{
   public int Id { get; set; }

}

public class DeleteAuthorCommandValidator : AbstractValidator<DeleteAuthorCommand>
{
   public DeleteAuthorCommandValidator()
   {
      RuleFor(v => v.Id).Must(v => v >= 0).WithMessage("Id must be non-negative number");
   }
}