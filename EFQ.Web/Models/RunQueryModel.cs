using AutoMapper;
using EFQ.Web.Entities;
using System.Collections.Generic;

namespace JDege.EFQ.Web.Models
{
    // TODO: Move js classes into .cshtml files
    public class RunQueryModel
    {
        public int StoredQueryId { get; set; }
        public string Title { get; set; }
        public string Model { get; set; }
        public string Query { get; set; }
        public string Description { get; set; }
        public string ReturnController { get; set; }

        public IEnumerable<Parameter> Parameters { get; set; }

        public class Parameter
        {
            public string Name { get; set; }
            public string Key { get; set; }
            public string Type { get; set; }
            public string DropdownUrl { get; set; }
        }
    }

    public class RunQueryModelProfile : Profile
    {
        public RunQueryModelProfile()
        {
            CreateMap<StoredQuery, RunQueryModel>()
                .ForMember(dest => dest.StoredQueryId, opt => opt.MapFrom(src => src.StoredQueryId))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Model, opt => opt.MapFrom((src, dest, destMember, context) => context.Items["Model"]))
                .ForMember(dest => dest.Query, opt => opt.MapFrom(src => src.Query))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Parameters, opt => opt.MapFrom((src, dest, destMember, context) => context.Items["Parameters"]))
                .ForMember(dest => dest.ReturnController, opt => opt.MapFrom((src, dest, destMember, context) => context.Items["ReturnController"]))
                ;
        }
    }

}
