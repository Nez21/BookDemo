using MediatR;
using BookDemo.Domain.Entities;
using System.Threading.Tasks;
using System.Threading;
using BookDemo.Domain.Repositories;
using AutoMapper;

namespace BookDemo.Application.Features.Authors.Commands.CreateAuthor
{
   public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, Author>
   {
      private readonly IAuthorRepository _authorRepository;
      private readonly IMapper _mapper;

      public CreateAuthorCommandHandler(IAuthorRepository authorRepository, IMapper mapper)
      {
         _authorRepository = authorRepository;
         _mapper = mapper;
      }

      public async Task<Author> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
      {
         var author = _mapper.Map<Author>(request);

         _authorRepository.Add(author);
         await _authorRepository.SaveAsync(cancellationToken);

         return author;
      }
   }
}