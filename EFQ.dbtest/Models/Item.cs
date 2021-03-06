using System;
using System.Collections.Generic;

namespace JDege.EFQ.dbtest.Models
{
    public partial class Item
    {
        public Item()
        {
            this.Children = new HashSet<Child>();
        }

        public string itemId { get; set; }
        public string name { get; set; }
        public string parentId { get; set; }
        public Nullable<System.DateTime> when { get; set; }

        // I had hoped I'd be able to test DateTimeOffset, but SqlLite doesn't support it.
        // public Nullable<System.DateTimeOffset> whenOffset { get; set; }

        public Nullable<int> amount { get; set; }

        public virtual ICollection<Child> Children { get; set; }
        public virtual Parent Parent { get; set; }
    }
}