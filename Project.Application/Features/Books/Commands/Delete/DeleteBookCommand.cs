using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Project.Application.Features.Books.Dtos;
using Project.Application.Features.Books.Rules;
using Project.Application.Services.Repositories;

namespace Project.Application.Features.Books.Commands.Delete
{
    public class DeleteBookCommand : IRequest<BookDto>
    {
        public int Id { get; set; }

        public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, BookDto>
        {
            private readonly IBookRepository _bookRepository;
            private readonly IMapper _mapper;
            private readonly BookBusinessRules _rules;

            public DeleteBookCommandHandler(IBookRepository bookRepository, IMapper mapper, BookBusinessRules rules)
            {
                _bookRepository = bookRepository;
                _mapper = mapper;
                _rules = rules;
            }

            public async Task<BookDto> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
            {
                var book = await _rules.CheckIfBookExistsByIdReturnBook(request.Id);

                await _bookRepository.DeleteAsync(book);

                return _mapper.Map<BookDto>(book);
            }
        }
    }
}
