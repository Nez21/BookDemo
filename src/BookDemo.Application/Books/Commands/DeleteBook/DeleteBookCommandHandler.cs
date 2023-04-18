using MediatR;
using BookDemo.Domain.Entities;
using System.Threading.Tasks;
using System.Threading;
using BookDemo.Domain.Repositories;
using AutoMapper;
using BookDemo.Application.Common.Exceptions;

namespace BookDemo.Application.Books.Commands.DeleteBook;

public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, Book>
{
   private readonly IBookRepository _bookRepository;
   private readonly IMapper _mapper;

   public DeleteBookCommandHandler(IBookRepository bookRepository, IMapper mapper)
   {
      _bookRepository = bookRepository;
      _mapper = mapper;
   }

   public async Task<Book> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
   {
      var book = _bookRepository.DeleteBook(request.Id);
      await _bookRepository.SaveAsync(cancellationToken);

      if (book == null)
      {
         throw new NotFoundException("Book", request.Id);
      }

      return book;
   }
}