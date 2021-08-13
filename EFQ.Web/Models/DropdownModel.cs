using AutoMapper;

using JDege.EFQ.Web.Entities;

namespace JDege.EFQ.Web.Models
{
    public class DropdownModel
    {
        public string value { get; set; }
        public string text { get; set; }
        public EFQ query { get; set; }
    }
    public class ArtistDropdownModelProfile : Profile
    {
        public ArtistDropdownModelProfile()
        {
            CreateMap<Artist, DropdownModel>()
                .ForMember(dest => dest.value, opt => opt.MapFrom(src => src.ArtistId))
                .ForMember(dest => dest.text, opt => opt.MapFrom(src => $"{src.Name} [{src.ArtistId}]"))
                .ForMember(dest => dest.query, opt => opt.Ignore())
                ;
            CreateMap<Customer, DropdownModel>()
                .ForMember(dest => dest.value, opt => opt.MapFrom(src => src.CustomerId))
                .ForMember(dest => dest.text, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName} [{src.CustomerId}]"))
                .ForMember(dest => dest.query, opt => opt.Ignore())
                ;
            CreateMap<MediaType, DropdownModel>()
                .ForMember(dest => dest.value, opt => opt.MapFrom(src => src.MediaTypeId))
                .ForMember(dest => dest.text, opt => opt.MapFrom(src => $"{src.Name} [{src.MediaTypeId}]"))
                .ForMember(dest => dest.query, opt => opt.Ignore())
                ;
        }
    }
}