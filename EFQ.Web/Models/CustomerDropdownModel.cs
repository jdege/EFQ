using AutoMapper;
using EFQ.Web.Entities;

namespace JDege.EFQ.Web.Models
{
    public class CustomerDropdownModel
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
    }

    public class CustomerDropdownModelProfile : Profile
    {
        public CustomerDropdownModelProfile()
        {
            CreateMap<Customer, CustomerDropdownModel>()
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.CustomerId))
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                ;
        }
    }
}