using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using core.Application.Rules;
using Core.CrossCuttingConcers.Exceptions;
using Core.Persistence.Paging;
using Project.Application.Services.CategoryService;
using static Project.Application.Features.Categories.Constants.CategoryMessages;
using Project.Application.Services.Repositories;
using Project.Domain.Entities;

namespace Project.Application.Features.Categories.Rules
{
    public class CategoryBusinessRules : BaseBusinessRules
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICategoryService _categoryService;

        public CategoryBusinessRules(ICategoryRepository categoryRepository, ICategoryService categoryService)
        {
            _categoryRepository = categoryRepository;
            _categoryService = categoryService;
        }

        public async Task CheckIfCategoryNameIsUnique(string name)
        {
            var category = await _categoryRepository.GetAsync(x => x.Name == name);
            if (category != null) throw new BusinessException(CategoryNameAlreadyExist);
        }

        public async Task<Category> CheckIfCategoryExistsByIdReturnCategory(int id)
        {
            var category = await _categoryService.GetCategoryById(id);
            if (category == null)
            {
                throw new BusinessException(CategoryNotFound);
            }

            return category;
        }

        public void CheckIfCategoryListIsEmpty(IPaginate<Category> categories)
        {
            if (categories.Items.Count == 0) throw new BusinessException(CategoryListIsEmpty);
        }
    }
}
