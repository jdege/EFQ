using AutoMapper;
// #TODO: make namespaces consistent
using EFQ.Web.Entities;

namespace JDege.EFQ.Web.Models
{
    public class AlbumModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ArtistName { get; set; }
    }

    public class AlbumModelProfile : Profile
    {
        public AlbumModelProfile()
        {
            CreateMap<Album, AlbumModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.AlbumId))
                .ForMember(dest => dest.ArtistName, opt => opt.MapFrom(src => src.Artist.Name))
                ;
        }
    }
}
