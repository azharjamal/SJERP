
using AutoMapper;
using SJERP.API.DTOs.Book;
using SJERP.API.DTOs.Category;
using SJERP.Domain.Models;

namespace SJERP.API.Configuration
{
    public class AutoMapperConfig: Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Category, CatgoryAddDto>().ReverseMap();
            CreateMap<Category, CatgoryEditDto>().ReverseMap();
            CreateMap<Category, CatgoryResultDto>().ReverseMap();

            CreateMap<Book, BookAddDto>().ReverseMap();
            CreateMap<Book, BookEditDto>().ReverseMap();
            CreateMap<Book, BookResultDto>().ReverseMap();
        }
    }
}
