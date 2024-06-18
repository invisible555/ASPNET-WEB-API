using AutoMapper;
using Projekt.Dto.Books;
using Projekt.Model.Entities;

namespace Projekt.Api.Configurations.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile() 
        {
            CreateMap<Book, BookDto>()
                .ForMember(x => x.Author, y => y.MapFrom(s => s.Author == null ? null : s.Author ))
                .ForMember(x => x.Publisher, y => y.MapFrom(s => s.Publisher == null ? null : s.Publisher));

        }
    }
}
