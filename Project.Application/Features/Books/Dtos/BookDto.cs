using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using core.Application.Dto;

namespace Project.Application.Features.Books.Dtos
{
    public class BookDto : IDto
    {
        public int Id { get; }
        public string Name { get; }
        public string Author { get; }
        public string Publisher { get; }
        public string ISBN { get; }

        public BookDto(int id, string name, string author, string publisher, string isbn)
        {
            Id = id;
            Name = name;
            Author = author;
            Publisher = publisher;
            ISBN = isbn;
        }
    }

}
