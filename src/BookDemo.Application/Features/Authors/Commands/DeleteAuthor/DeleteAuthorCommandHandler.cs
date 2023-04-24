using MediatR;
using BookDemo.Domain.Entities;
using System.Threading.Tasks;
using System.Threading;
using BookDemo.Domain.Repositories;
using BookDemo.Application.Common.Exceptions;
using System.Linq;

namespace BookDemo.Application.Features.Authors.Commands.DeleteAuthor
{
   public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand, Author>
   {
      private readonly IAuthorRepository _authorRepository;

      public DeleteAuthorCommandHandler(IAuthorRepository authorRepository)
      {
         _authorRepository = authorRepository;
      }

      public async Task<Author> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
      {
         var author = _authorRepository.GetAll().FirstOrDefault(a => a.Id == request.Id);

         if (author == null)
         {
            throw new NotFoundException("Author", request.Id);
         }

         _authorRepository.Delete(author);
         await _authorRepository.SaveAsync(cancellationToken);

         return author;
      }
   }
}