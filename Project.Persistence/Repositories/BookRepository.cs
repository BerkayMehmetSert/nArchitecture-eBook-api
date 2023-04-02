using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistence.Repositories;
using Project.Application.Services.Repositories;
using Project.Domain.Entities;
using Project.Persistence.Contexts;

namespace Project.Persistence.Repositories
{
    public class BookRepository : EfRepositoryBase<Book, BaseDbContext>, IBookRepository
    {
        public BookRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
