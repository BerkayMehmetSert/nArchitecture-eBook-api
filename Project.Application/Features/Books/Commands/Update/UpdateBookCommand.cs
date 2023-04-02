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

namespace Project.Application.Features.Books.Commands.Update
{
    public class UpdateBookCommand : IRequest<BookDto>
    {
        public UpdateBookRequest Request { get; set; }

        public UpdateBookCommand(UpdateBookRequest request)
        {
            Request = request;
        }

        public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, BookDto>
        {
            private readonly IBookRepository _bookRepository;
            private readonly ICategoryService _categoryService;
            private readonly IMapper _mapper;
            private readonly BookBusinessRules _rules;

            public UpdateBookCommandHandler(IBookRepository bookRepository, ICategoryService categoryService, IMapper mapper, BookBusinessRules rules)
            {
                _bookRepository = bookRepository;
                _categoryService = categoryService;
                _mapper = mapper;
                _rules = rules;
            }

            public async Task<BookDto> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
            {
                var book = await _rules.CheckIfBookExistsByIdReturnBook(request.Request.Id);

                var updatedBook = _mapper.Map(request.Request, book);

                updatedBook.Category = await _categoryService.GetCategoryById(request.Request.CategoryId);

                await _bookRepository.UpdateAsync(updatedBook);

                return _mapper.Map<BookDto>(updatedBook);
            }
        }
    }
}
