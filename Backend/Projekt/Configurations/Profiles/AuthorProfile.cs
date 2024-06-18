using Projekt.Dto.Authors;
using Projekt.Dto.Books;
using Projekt.Model.Entities;
using AutoMapper;


namespace Projekt.Api.Configurations.Profiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<Author, AuthorDto>()
                 .ForMember(x => x.Publisher, y => y.MapFrom(s => s.Publisher == null ? null : s.Publisher))
                    .ForMember(x => x.Books, y => y.MapFrom(s => s.Books == null ? null : s.Books));
            CreateMap<Book, BookDto>() 
            .ForMember(dest => dest.Author, opt => opt.Ignore()); 

        }
    }
}
