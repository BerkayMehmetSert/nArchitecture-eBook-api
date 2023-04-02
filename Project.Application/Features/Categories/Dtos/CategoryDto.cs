using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using core.Application.Dto;

namespace Project.Application.Features.Categories.Dtos
{
    public class CategoryDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public CategoryDto(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
