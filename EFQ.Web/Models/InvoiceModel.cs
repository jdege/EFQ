using System;
using AutoMapper;

using JDege.EFQ.Web.Entities;

namespace JDege.EFQ.Web.Models
{
    public class InvoiceModel
    {
        public string CustomerName { get; set; }
        public DateTimeOffset InvoiceDate { get; set; }
        public string BillingAddress { get; set; }
        public string BillingCity { get; set; }
        public string BillingState { get; set; }
        public string BillingCountry { get; set; }
        public string BillingPostalCode { get; set; }
        public decimal Total { get; set; }
    }

    public class InvoiceModelProfile : Profile
    {
        public InvoiceModelProfile()
        {
            CreateMap<Invoice, InvoiceModel>()
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => $"{src.Customer.FirstName} {src.Customer.LastName}"))
                .ForMember(dest => dest.InvoiceDate, opt => opt.MapFrom(src => new DateTimeOffset(src.InvoiceDate)))
                ;
        }
    }
}