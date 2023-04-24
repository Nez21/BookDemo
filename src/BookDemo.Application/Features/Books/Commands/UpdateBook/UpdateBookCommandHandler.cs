using MediatR;
using BookDemo.Domain.Entities;
using System.Threading.Tasks;
using System.Threading;
using BookDemo.Domain.Repositories;
using AutoMapper;
using System.Linq;
using BookDemo.Application.Common.Exceptions;

namespace BookDemo.Application.Features.Books.Commands.UpdateBook;

public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Book>
{
   private readonly IBookRepository _bookRepository;
   private readonly IAuthorRepository _authorRepository;
   private readonly IMapper _mapper;

   public UpdateBookCommandHandler(IBookRepository bookRepository, IAuthorRepository authorRepository, IMapper mapper)
   {
      _bookRepository = bookRepository;
      _authorRepository = authorRepository;
      _mapper = mapper;
   }

   public async Task<Book> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
   {
      var hasBook = _bookRepository.GetAll().FirstOrDefault(a => a.Id == request.Id) != null;

      if (!hasBook)
      {
         throw new NotFoundException("Book", request.AuthorId);
      }

      var hasAuthor = _authorRepository.GetAll().FirstOrDefault(a => a.Id == request.AuthorId) != null;

      if (!hasAuthor)
      {
         throw new NotFoundException("Author", request.AuthorId);
      }

      var book = _mapper.Map<Book>(request);

      _bookRepository.Update(book);
      await _bookRepository.SaveAsync(cancellationToken);

      return book;
   }
}