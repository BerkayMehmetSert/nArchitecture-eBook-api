using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Application.Services.Repositories;
using Project.Domain.Entities;

namespace Project.Application.Services.CategoryService
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return await _categoryRepository.GetAsync(x => x.Id == id);
        }
    }
}
