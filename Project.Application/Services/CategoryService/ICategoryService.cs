using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Domain.Entities;

namespace Project.Application.Services.CategoryService
{
    public interface ICategoryService
    {
        Task<Category> GetCategoryById(int id);
    }
}
