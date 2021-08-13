using System.Collections.Generic;

namespace JDege.EFQ.dbtest.Models
{
    public partial class Parent
    {
        public Parent()
        {
            this.Items = new HashSet<Item>();
        }

        public string parentId { get; set; }
        public string name { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}