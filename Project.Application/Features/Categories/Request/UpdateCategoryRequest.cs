using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using core.Application.Dto;

namespace Project.Application.Features.Categories.Request
{
    public class UpdateCategoryRequest : IDto
    {
        public int Id { get; }
        public string Name { get; }


        public UpdateCategoryRequest(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
