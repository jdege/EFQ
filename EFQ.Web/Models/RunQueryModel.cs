using System.Collections.Generic;

namespace JDege.EFQ.Web.Models
{
    public class RunQueryModel
    {
        public string Title { get; set; }
        public IList<TrackModel> TrackModels { get; set; }
    }
}