using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistence.Paging;
using Project.Application.Features.Books.Dtos;

namespace Project.Application.Features.Books.Models
{
    public class BookListModel : BasePageableModel
    {
        public IList<BookDto> Items { get; set; }
    }
}
