using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Persistence.Paging;
using Project.Application.Features.Books.Commands.Create;
using Project.Application.Features.Books.Dtos;
using Project.Application.Features.Books.Models;
using Project.Application.Features.Books.Requests;
using Project.Domain.Entities;

namespace Project.Application.Features.Books.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, CreateBookRequest>().ReverseMap();
            CreateMap<Book, UpdateBookRequest>().ReverseMap();
            CreateMap<Book, BookDto>().ReverseMap();
            CreateMap<IPaginate<Book>, BookListModel>().ReverseMap();
        }
    }
}
