using System;
using System.Collections.Generic;

namespace JDege.EFQ.Web.Models
{
    public class RunTrackQueryModel
    {
        public string Title { get; set; }
        public string Query { get; set; }
        public string Description { get; set; }
        public IList<TrackModel> TrackModels { get; set; }
    }

    public class RunInvoiceQueryModel
    {
        public string Title { get; set; }
        public string Query { get; set; }
        public string Description { get; set; }
        public IList<InvoiceModel> InvoiceModels { get; set; }
    }
}