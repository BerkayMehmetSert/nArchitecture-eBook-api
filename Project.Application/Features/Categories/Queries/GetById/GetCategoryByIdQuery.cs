using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Project.Application.Features.Categories.Dtos;
using Project.Application.Features.Categories.Rules;

namespace Project.Application.Features.Categories.Queries.GetById
{
    public class GetCategoryByIdQuery : IRequest<CategoryDto>
    {
        public int Id { get; set; }

        public class GetByIdCategoryQueryHandler : IRequestHandler<GetCategoryByIdQuery, CategoryDto>
        {
            private readonly IMapper _mapper;
            private readonly CategoryBusinessRules _rules;

            public GetByIdCategoryQueryHandler(IMapper mapper, CategoryBusinessRules rules)
            {
                _mapper = mapper;
                _rules = rules;
            }

            public async Task<CategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
            {
                var category = await _rules.CheckIfCategoryExistsByIdReturnCategory(request.Id);

                return _mapper.Map<CategoryDto>(category);
            }
        }
    }
}
