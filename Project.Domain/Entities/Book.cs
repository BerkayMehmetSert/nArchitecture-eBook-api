using Core.Persistence.Repositories;

namespace Project.Domain.Entities
{
    public class Book : Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string ISBN { get; set; }

        public virtual int CategoryId { get; set; }
        public virtual Category? Category { get; set; }

        public Book()
        {

        }

        public Book(int id, string name, string author, string publisher, string isbn, int categoryId) : this()
        {
            Id = id;
            Name = name;
            Author = author;
            Publisher = publisher;
            ISBN = isbn;
            CategoryId = categoryId;
        }
    }
}