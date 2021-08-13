using Microsoft.EntityFrameworkCore;

using JDege.EFQ.Web.Entities;

// TODO: See if we can enable nullable reference types
#nullable disable

namespace JDege.EFQ.Web.DbContexts
{
    public partial class ChinookContext : DbContext
    {
        public ChinookContext(DbContextOptions<ChinookContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<InvoiceLine> InvoiceLines { get; set; }
        public virtual DbSet<MediaType> MediaTypes { get; set; }
        public virtual DbSet<Playlist> Playlists { get; set; }
        public virtual DbSet<PlaylistTrack> PlaylistTracks { get; set; }
        public virtual DbSet<Track> Tracks { get; set; }
        public virtual DbSet<StoredQuery> StoredQueries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.ApplyConfiguration(new AlbumConfiguration());

            modelBuilder.ApplyConfiguration(new ArtistConfiguration());

            modelBuilder.ApplyConfiguration(new CustomerConfiguration());

            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());

            modelBuilder.ApplyConfiguration(new GenreConfiguration());

            modelBuilder.ApplyConfiguration(new InvoiceConfiguration());

            modelBuilder.ApplyConfiguration(new InvoiceLineConfiguration());

            modelBuilder.ApplyConfiguration(new MediaTypeConfiguration());

            modelBuilder.ApplyConfiguration(new PlaylistConfiguration());

            modelBuilder.ApplyConfiguration(new PlaylistTrackConfiguration());

            modelBuilder.ApplyConfiguration(new TrackConfiguration());

            modelBuilder.ApplyConfiguration(new StoredQueryConfiguration());

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}