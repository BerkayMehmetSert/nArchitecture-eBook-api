using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Project.Application.Features.Categories.Dtos;
using Project.Application.Features.Categories.Rules;
using Project.Application.Services.Repositories;

namespace Project.Application.Features.Categories.Commands.Delete
{
    public class DeleteCategoryCommand : IRequest<CategoryDto>
    {
        public int Id { get; set; }

        public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, CategoryDto>
        {
            private readonly ICategoryRepository _categoryRepository;
            private readonly IMapper _mapper;
            private readonly CategoryBusinessRules _rules;

            public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper, CategoryBusinessRules rules)
            {
                _categoryRepository = categoryRepository;
                _mapper = mapper;
                _rules = rules;
            }

            public async Task<CategoryDto> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
            {
                var category = await _rules.CheckIfCategoryExistsByIdReturnCategory(request.Id);

                await _categoryRepository.DeleteAsync(category);

                return _mapper.Map<CategoryDto>(category);
            }
        }
    }
}
