using MediatR;
using BookDemo.Domain.Entities;
using System.Threading.Tasks;
using System.Threading;
using BookDemo.Domain.Repositories;
using AutoMapper;
using BookDemo.Application.Common.Exceptions;
using System.Linq;

namespace BookDemo.Application.Features.Books.Commands.DeleteBook;

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
      var book = _bookRepository.GetAll().FirstOrDefault(a => a.Id == request.Id);

      if (book == null)
      {
         throw new NotFoundException("Book", request.Id);
      }

      _bookRepository.Delete(book);
      await _bookRepository.SaveAsync(cancellationToken);

      return book;
   }
}