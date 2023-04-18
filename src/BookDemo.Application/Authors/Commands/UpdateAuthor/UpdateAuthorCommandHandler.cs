using MediatR;
using BookDemo.Domain.Entities;
using System.Threading.Tasks;
using System.Threading;
using BookDemo.Domain.Repositories;
using AutoMapper;
using System;
using System.Linq;
using BookDemo.Application.Common.Exceptions;

namespace BookDemo.Application.Authors.Commands.UpdateAuthor;

public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, Author>
{
   private readonly IAuthorRepository _authorRepository;
   private readonly IMapper _mapper;

   public UpdateAuthorCommandHandler(IAuthorRepository authorRepository, IMapper mapper)
   {
      _authorRepository = authorRepository;
      _mapper = mapper;
   }

   public async Task<Author> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
   {
      var hasAuthor = _authorRepository.GetAllAuthors().FirstOrDefault(a => a.Id == request.Id) != null;

      if (!hasAuthor)
      {
         throw new NotFoundException("Author", request.Id);
      }

      var author = _mapper.Map<Author>(request);

      _authorRepository.UpdateAuthor(author);
      await _authorRepository.SaveAsync(cancellationToken);

      return author;
   }
}