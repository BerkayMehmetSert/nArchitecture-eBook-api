using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using core.Application.Dto;

namespace Project.Application.Features.Categories.Request
{
    public class CreateCategoryRequest : IDto
    {
        public string Name { get; }

        public CreateCategoryRequest(string name)
        {
            Name = name;
        }
    }
}
