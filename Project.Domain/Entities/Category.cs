using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistence.Repositories;

namespace Project.Domain.Entities
{
    public class Category : Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }


        public Category()
        {
            Books = new HashSet<Book>();
        }

        public Category(int id, string name, ICollection<Book> books) : this()
        {
            Id = id;
            Name = name;
            Books = books;
        }
    }
}
