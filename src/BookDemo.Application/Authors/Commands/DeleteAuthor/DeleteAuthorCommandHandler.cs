using MediatR;
using BookDemo.Domain.Entities;
using System.Threading.Tasks;
using System.Threading;
using BookDemo.Domain.Repositories;
using AutoMapper;
using BookDemo.Application.Common.Exceptions;

namespace BookDemo.Application.Authors.Commands.DeleteAuthor;

public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand, Author>
{
   private readonly IAuthorRepository _authorRepository;
   private readonly IMapper _mapper;

   public DeleteAuthorCommandHandler(IAuthorRepository authorRepository, IMapper mapper)
   {
      _authorRepository = authorRepository;
      _mapper = mapper;
   }

   public async Task<Author> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
   {
      var author = _authorRepository.DeleteAuthor(request.Id);
      await _authorRepository.SaveAsync(cancellationToken);

      if (author == null)
      {
         throw new NotFoundException("Author", request.Id);
      }

      return author;
   }
}