using core.Application.Dto;

namespace Project.Application.Features.Categories.Dtos
{
    public class CategoryListDto : IDto
    {
        public int Id { get; }
        public string Name { get; }
        public IList<CategoryBookDto> Books { get; }

        public CategoryListDto(int id, string name, IList<CategoryBookDto> books)
        {
            Id = id;
            Name = name;
            Books = books;
        }
    }
}