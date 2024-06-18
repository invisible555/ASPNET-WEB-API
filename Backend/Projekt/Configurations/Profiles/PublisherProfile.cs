using AutoMapper;
using Projekt.Dto.Books;
using Projekt.Dto.Publishers;
using Projekt.Model.Entities;

namespace Projekt.Api.Configurations.Profiles
{
    public class PublisherProfile : Profile
    {
        public PublisherProfile() 
        {
            CreateMap<Publisher, PublisherDto>()
                     .ForMember(x => x.Authors, y => y.MapFrom(s => s.Authors == null ? null : s.Authors))
                .ForMember(x => x.Books, y => y.MapFrom(s => s.Books == null ? null : s.Books));

        }
    }
}
