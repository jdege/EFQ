using AutoMapper;
using EFQ.Web.Entities;

namespace JDege.EFQ.Web.Models
{
    public class ArtistDropdownModel
    {
        public int ArtistId { get; set; }
        public string ArtistName { get; set; }
    }
    public class ArtistDropdownModelProfile : Profile
    {
        public ArtistDropdownModelProfile()
        {
            CreateMap<Artist, ArtistDropdownModel>()
                .ForMember(dest => dest.ArtistId, opt => opt.MapFrom(src => src.ArtistId))
                .ForMember(dest => dest.ArtistName, opt => opt.MapFrom(src => src.Name))
                ;
        }
    }
}

