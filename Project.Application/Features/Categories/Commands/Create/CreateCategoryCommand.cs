using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Project.Application.Features.Categories.Dtos;
using Project.Application.Features.Categories.Request;
using Project.Application.Features.Categories.Rules;
using Project.Application.Services.Repositories;
using Project.Domain.Entities;

namespace Project.Application.Features.Categories.Commands.Create
{
    public class CreateCategoryCommand : IRequest<CategoryDto>
    {
        public CreateCategoryRequest Request { get; set; }

        public CreateCategoryCommand(CreateCategoryRequest request)
        {
            Request = request;
        }

        public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CategoryDto>
        {
            private readonly ICategoryRepository _categoryRepository;
            private readonly IMapper _mapper;
            private readonly CategoryBusinessRules _rules;

            public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper, CategoryBusinessRules rules)
            {
                _categoryRepository = categoryRepository;
                _mapper = mapper;
                _rules = rules;
            }

            public async Task<CategoryDto> Handle(CreateCategoryCommand command, CancellationToken cancellationToken)
            {
                await _rules.CheckIfCategoryNameIsUnique(command.Request.Name);
                var category = _mapper.Map<Category>(command.Request);
                var save = await _categoryRepository.AddAsync(category);

                return _mapper.Map<CategoryDto>(save);
            }
        }
    }
}
