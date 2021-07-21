using System.Collections.Generic;
using AutoMapper;
using EFQ.Web.Entities;

namespace JDege.EFQ.Web.Models
{
    public class TrackModel
    {
        public TrackModel()
        {
            Customers = new List<Customer>();
        }
        public string TrackName { get; internal set; }
        public string AlbumTitle { get; internal set; }
        public string TrackComposer { get; internal set; }
        public IList<Customer> Customers { get; internal set; }

        public class Customer
        {
            public string FirstName { get; internal set; }
            public string LastName { get; internal set; }
        }
    }


    public class TrackModelProfile : Profile
    {
        public TrackModelProfile()
        {
            CreateMap<Track, TrackModel>()
                .ForMember(dest => dest.TrackName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.AlbumTitle, opt => opt.MapFrom(src => src.Album.Title))
                .ForMember(dest => dest.TrackComposer, opt => opt.MapFrom(src => src.Composer))
                .ForMember(dest => dest.Customers, opt => opt.MapFrom(src => src.InvoiceLines))
                ;

            CreateMap<InvoiceLine, TrackModel.Customer>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Invoice.Customer.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Invoice.Customer.LastName))
                ;
        }
    }
}
