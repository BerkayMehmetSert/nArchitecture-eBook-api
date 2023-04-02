using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.Categories.Constants
{
    public static class CategoryMessages
    {
        public const string CategoryNameAlreadyExist = "Category name already exists";
        public const string CategoryNotFound = "Category not found";
        public const string CategoryListIsEmpty = "Category list is empty";

        public const string CategoryNameIsRequired = "Category name is required";
        public const string CategoryNameIsMinimumCharacters = "Category name is minimum 2 characters";
    }
}
