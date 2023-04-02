using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using core.Application.Dto;

namespace Project.Application.Features.Books.Requests
{
    public class UpdateBookRequest : IDto
    {
        public int Id { get; set; }
        public string Name { get; }
        public string Author { get; }
        public string Publisher { get; }
        public int CategoryId { get; }

        public UpdateBookRequest(int id, string name, string author, string publisher, int categoryId)
        {
            Id = id;
            Name = name;
            Author = author;
            Publisher = publisher;
            CategoryId = categoryId;
        }
    }
}
