using System.Linq;
using MediatR;
using BookDemo.Domain.Entities;
using System.Threading.Tasks;
using System.Threading;
using BookDemo.Domain.Repositories;
using AutoMapper;
using BookDemo.Application.Common.Exceptions;
using BookDemo.Domain.Events;

namespace BookDemo.Application.Features.Books.Commands.CreateBook
{
   public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, Book>
   {
      private readonly IBookRepository _bookRepository;
      private readonly IAuthorRepository _authorRepository;
      private readonly IMapper _mapper;

      public CreateBookCommandHandler(IBookRepository bookRepository, IAuthorRepository authorRepository, IMapper mapper)
      {
         _bookRepository = bookRepository;
         _authorRepository = authorRepository;
         _mapper = mapper;
      }

      public async Task<Book> Handle(CreateBookCommand request, CancellationToken cancellationToken)
      {
         var hasAuthor = _authorRepository.GetAll().FirstOrDefault(a => a.Id == request.AuthorId) != null;

         if (!hasAuthor)
         {
            throw new NotFoundException("Author", request.AuthorId);
         }

         var book = _mapper.Map<Book>(request);

         book.DomainEvents.Add(new BookCreatedEvent { Book = book });
         _bookRepository.Add(book);
         await _bookRepository.SaveAsync(cancellationToken);

         return book;
      }
   }
}