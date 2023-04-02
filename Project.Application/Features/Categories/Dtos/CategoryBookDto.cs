using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using core.Application.Dto;

namespace Project.Application.Features.Categories.Dtos
{
    public class CategoryBookDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string ISBN { get; set; }

        public CategoryBookDto(int id, string name, string author, string publisher, string isbn)
        {
            Id = id;
            Name = name;
            Author = author;
            Publisher = publisher;
            ISBN = isbn;
        }
    }
}
