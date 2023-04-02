using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Application.Request;
using MediatR;
using Project.Application.Features.Books.Models;
using Project.Application.Features.Books.Rules;
using Project.Application.Services.Repositories;

namespace Project.Application.Features.Books.Queries.GetAll
{
    public class GetAllBookQuery : IRequest<BookListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetAllBookQueryHandler : IRequestHandler<GetAllBookQuery, BookListModel>
        {
            private readonly IBookRepository _bookRepository;
            private readonly IMapper _mapper;
            private readonly BookBusinessRules _rules;

            public GetAllBookQueryHandler(IBookRepository bookRepository, IMapper mapper, BookBusinessRules rules)
            {
                _bookRepository = bookRepository;
                _mapper = mapper;
                _rules = rules;
            }

            public async Task<BookListModel> Handle(GetAllBookQuery request, CancellationToken cancellationToken)
            {
                var books = await _bookRepository.GetListAsync(
                    size: request.PageRequest.Size,
                    index: request.PageRequest.Page
                );

                _rules.CheckIfBookListIsEmpty(books);

                return _mapper.Map<BookListModel>(books);
            }
        }
    }
}
