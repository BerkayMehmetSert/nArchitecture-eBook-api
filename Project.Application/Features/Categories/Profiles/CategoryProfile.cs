using AutoMapper;
using Core.Persistence.Paging;
using Project.Application.Features.Books.Dtos;
using Project.Application.Features.Categories.Dtos;
using Project.Application.Features.Categories.Models;
using Project.Application.Features.Categories.Request;
using Project.Domain.Entities;

namespace Project.Application.Features.Categories.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CreateCategoryRequest>().ReverseMap();
            CreateMap<Category, UpdateCategoryRequest>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryListDto>().ReverseMap();
            CreateMap<Book, CategoryBookDto>().ReverseMap();
            CreateMap<IPaginate<Category>, CategoryListModel>().ReverseMap();
        }
    }
}