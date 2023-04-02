using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Application.Request;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Project.Application.Features.Categories.Models;
using Project.Application.Features.Categories.Rules;
using Project.Application.Services.Repositories;

namespace Project.Application.Features.Categories.Queries.GetAll
{
    public class GetAllCategoryQuery : IRequest<CategoryListModel>
    {
        public PageRequest PageRequest { get; set; }

        public GetAllCategoryQuery(PageRequest pageRequest)
        {
            PageRequest = pageRequest;
        }

        public class GetALlCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery, CategoryListModel>
        {
            private readonly ICategoryRepository _categoryRepository;
            private readonly IMapper _mapper;
            private readonly CategoryBusinessRules _rules;

            public GetALlCategoryQueryHandler(ICategoryRepository categoryRepository, IMapper mapper, CategoryBusinessRules rules)
            {
                _categoryRepository = categoryRepository;
                _mapper = mapper;
                _rules = rules;
            }

            public async Task<CategoryListModel> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
            {
                var categories = await _categoryRepository.GetListAsync(
                    include: x => x.Include(y => y.Books),
                    size: request.PageRequest.Size,
                    index: request.PageRequest.Page
                    );

                _rules.CheckIfCategoryListIsEmpty(categories);

                return _mapper.Map<CategoryListModel>(categories);
            }
        }
    }
}
