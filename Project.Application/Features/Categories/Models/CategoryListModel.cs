using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistence.Paging;
using Project.Application.Features.Categories.Dtos;

namespace Project.Application.Features.Categories.Models
{
    public class CategoryListModel : BasePageableModel
    {
        public IList<CategoryListDto> Items { get; set; }
    }
}
