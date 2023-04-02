using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Project.Application.Features.Books.Dtos;
using Project.Application.Features.Books.Requests;
using Project.Application.Features.Books.Rules;
using Project.Application.Services.CategoryService;
using Project.Application.Services.Repositories;
using Project.Domain.Entities;
using static Project.Application.Utilities.ISBNHelper;
namespace Project.Application.Features.Books.Commands.Create
{
    public class CreateBookCommand : IRequest<BookDto>
    {
        public CreateBookRequest Request { get; set; }

        public CreateBookCommand(CreateBookRequest request)
        {
            Request = request;
        }

        public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, BookDto>
        {
            private readonly IBookRepository _bookRepository;
            private readonly ICategoryService _categoryService;
            private readonly IMapper _mapper;
            private readonly BookBusinessRules _rules;

            public CreateBookCommandHandler(IBookRepository bookRepository, ICategoryService categoryService, IMapper mapper, BookBusinessRules rules)
            {
                _bookRepository = bookRepository;
                _categoryService = categoryService;
                _mapper = mapper;
                _rules = rules;
            }

            public async Task<BookDto> Handle(CreateBookCommand request, CancellationToken cancellationToken)
            {
                _rules.CheckIfBookNameIsUnique(request.Request.Name);

                var book = _mapper.Map<Book>(request.Request);

                book.Category = await _categoryService.GetCategoryById(request.Request.CategoryId);
                book.ISBN = CalculateISBN();

                await _bookRepository.AddAsync(book);

                return _mapper.Map<BookDto>(book);
            }
        }
    }
}
