using System.Collections.Generic;

#nullable disable

namespace JDege.EFQ.Web.Entities
{
    public partial class Genre
    {
        public Genre()
        {
            Tracks = new HashSet<Track>();
        }

        public int GenreId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Track> Tracks { get; set; }
    }
}
