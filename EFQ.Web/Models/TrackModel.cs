using AutoMapper;
using EFQ.Web.Entities;

namespace JDege.EFQ.Web.Models
{
    public class TrackModel
    {
        public string TrackName { get; internal set; }
        public string AlbumTitle { get; internal set; }
        public string TrackComposer { get; internal set; }
        public string CustomerFirstName { get; internal set; }
        public string CustomerLastName { get; internal set; }
    }


    public class TrackModelProfile : Profile
    {
        public TrackModelProfile()
        {
            CreateMap<Track, TrackModel>()
                .ForMember(dest => dest.TrackName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.AlbumTitle, opt => opt.MapFrom(src => src.Album.Title))
                .ForMember(dest => dest.TrackComposer, opt => opt.MapFrom(src => src.Composer))
                // #TODO: Need to turn customers into a list - it's a one-to-many mapping!
                .ForMember(dest => dest.CustomerFirstName, opt => opt.Ignore())
                .ForMember(dest => dest.CustomerLastName, opt => opt.Ignore())
                ;
        }
    }
}
