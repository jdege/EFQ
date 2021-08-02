using System;
using System.Collections.Generic;

namespace JDege.EFQ.Web.Models
{
    public class RunTrackQueryModel
    {
        public string Title { get; set; }
        public string Query { get; set; }
        public string Context { get; set; }
        public string Description { get; set; }
        public string ReturnController { get; set; }
        public IList<TrackModel> TrackModels { get; set; }
    }
}