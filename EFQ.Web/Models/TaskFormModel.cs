using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JDege.EFQ.Web.Models
{
    public class TrackFormModel
    {
        public string Title { get; set; }

        public IEnumerable<SelectListItem> Customers { get; set; }
        [DisplayName("Customer")]
        public string CustomerId { get; set; }

        public IEnumerable<SelectListItem> Artists { get; set; }
        [DisplayName("Artist")]
        public string ArtistId { get; set; }

        public IList<TrackModel> TrackModels { get; set; }
    }
}