using System;
using System.Collections.Generic;

namespace JDege.EFQ.Web.Models
{
    // TODO: Move js classes into .cshtml files
    public class RunTrackQueryModel
    {
        public int StoredQueryId { get; set; }
        public string Title { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public string ReturnController { get; set; }

        public IEnumerable<Parameter> Parameters { get; set; }

        public class Parameter
        {
            public string Name { get; set; }
            public string Type { get; set; }
            public string DropdownUrl { get; set; }
        }
    }
}
