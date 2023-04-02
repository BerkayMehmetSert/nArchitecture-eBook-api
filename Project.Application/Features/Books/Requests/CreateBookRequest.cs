using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using core.Application.Dto;

namespace Project.Application.Features.Books.Requests
{
    public class CreateBookRequest : IDto
    {
        public string Name { get; }
        public string Author { get; }
        public string Publisher { get; }
        public int CategoryId { get; }

        public CreateBookRequest(string name, string author, string publisher, int categoryId)
        {
            Name = name;
            Author = author;
            Publisher = publisher;
            CategoryId = categoryId;
        }
    }
}
