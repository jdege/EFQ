using AutoMapper;

using JDege.EFQ.Web.Entities;

namespace JDege.EFQ.Web.Models
{
    public class StoredQueryModel
    {
        public int Id { get; set; }

        public string Area { get; set; }
        public string BaseTable { get; set; }
        public string Name { get; set; }
        public string Query { get; set; }
        public string Description { get; set; }
    }

    public class StoredQueryModelProfile : Profile
    {
        public StoredQueryModelProfile()
        {
            CreateMap<StoredQuery, StoredQueryModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.StoredQueryId))
                ;
        }
    }
}