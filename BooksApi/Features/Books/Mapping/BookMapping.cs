using AutoMapper;
using BooksApi.Core.Entities;
using BooksApi.Features.Books.Dtos;

namespace BooksApi.Features.Books.Mapping
{
    public class BookMapping : Profile
    {
        public BookMapping()
        {
            CreateMap<Book, BookDto>();
            CreateMap<BookDto, Book>();
        }
    }
}
