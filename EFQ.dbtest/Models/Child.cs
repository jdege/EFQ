using System;
using System.Collections.Generic;

namespace JDege.EFQ.dbtest.Models
{
    public partial class Child
    {
        public string childId { get; set; }
        public string name { get; set; }
        public string itemId { get; set; }

        public virtual Item Item { get; set; }
    }
}
