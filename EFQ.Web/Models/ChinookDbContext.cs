﻿using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EFQ.Web.Models
{
    public partial class ChinookDbContext : DbContext
    {
        // We don't ever want to use this...
        // public ChinookDbContext()
        // {
        // }

        public ChinookDbContext(DbContextOptions<ChinookDbContext> options)
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

        //         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //         {
        //             if (!optionsBuilder.IsConfigured)
        //             {
        // #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        //                 optionsBuilder.UseSqlServer("Server=localhost;Database=Chinook;User Id=SA;Password=Password1");
        //             }
        //         }

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

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}