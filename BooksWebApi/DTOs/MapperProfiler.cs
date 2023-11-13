using AutoMapper;
using BooksWebApi.Entities;

namespace BooksWebApi.DTOs
{
    public class MapperProfiler : Profile
    {
        public MapperProfiler() 
        {
            CreateMap<Book, BookInputDTO>();
            CreateMap<BookInputDTO, Book>();
            CreateMap<Book, BookOutputDTO>();
            CreateMap<BookOutputDTO, Book>();
        }
    }
}
