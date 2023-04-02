using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Project.Application.Features.Books.Dtos;
using Project.Application.Features.Books.Rules;

namespace Project.Application.Features.Books.Queries.GetById
{
    public class GetBookByIdQuery : IRequest<BookDto>
    {
        public int id { get; set; }

        public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, BookDto>
        {
            private readonly IMapper _mapper;
            private readonly BookBusinessRules _rules;

            public GetBookByIdQueryHandler(IMapper mapper, BookBusinessRules rules)
            {
                _mapper = mapper;
                _rules = rules;
            }

            public async Task<BookDto> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
            {
                var book = await _rules.CheckIfBookExistsByIdReturnBook(request.id);

                return _mapper.Map<BookDto>(book);
            }
        }
    }
}
