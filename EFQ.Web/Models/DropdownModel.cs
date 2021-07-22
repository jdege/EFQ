using AutoMapper;
using EFQ.Web.Entities;

namespace JDege.EFQ.Web.Models
{
    public class DropdownModel
    {
        public string Value { get; set; }
        public string text { get; set; }
    }
    public class ArtistDropdownModelProfile : Profile
    {
        public ArtistDropdownModelProfile()
        {
            CreateMap<Artist, DropdownModel>()
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.ArtistId))
                .ForMember(dest => dest.text, opt => opt.MapFrom(src => $"{src.Name} [{src.ArtistId}]"))
                ;
            CreateMap<Customer, DropdownModel>()
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.CustomerId))
                .ForMember(dest => dest.text, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName} [{src.CustomerId}]"))
                ;
        }
    }
}

