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

namespace Project.Application.Features.Categories.Commands.Update
{
    public class UpdateCategoryCommand : IRequest<CategoryDto>
    {
        public UpdateCategoryRequest Request { get; set; }

        public UpdateCategoryCommand(UpdateCategoryRequest request)
        {
            Request = request;
        }

        public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, CategoryDto>
        {
            private readonly ICategoryRepository _categoryRepository;
            private readonly IMapper _mapper;
            private readonly CategoryBusinessRules _rules;

            public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper, CategoryBusinessRules rules)
            {
                _categoryRepository = categoryRepository;
                _mapper = mapper;
                _rules = rules;
            }

            public async Task<CategoryDto> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
            {
                var category = await _rules.CheckIfCategoryExistsByIdReturnCategory(request.Request.Id);

                var updatedCategory = _mapper.Map(request.Request, category);

                await _categoryRepository.UpdateAsync(updatedCategory);

                return _mapper.Map<CategoryDto>(updatedCategory);
            }
        }
    }
}
