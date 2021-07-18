using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JDege.EFQ.Web.Entities
{
    internal class PlaylistConfiguration : IEntityTypeConfiguration<Playlist>
    {
        public void Configure(EntityTypeBuilder<Playlist> builder)
        {
            builder.ToTable("Playlist");

            builder.Property(e => e.Name).HasMaxLength(120);

            seedData(builder);
        }
        private void seedData(EntityTypeBuilder<Playlist> builder)
        {
            builder.HasData(
                new Playlist
                {
                    PlaylistId = 1,
                    Name = "Music"
                },
                new Playlist
                {
                    PlaylistId = 2,
                    Name = "Movies"
                },
                new Playlist
                {
                    PlaylistId = 3,
                    Name = "TV Shows"
                },
                new Playlist
                {
                    PlaylistId = 4,
                    Name = "Audiobooks"
                },
                new Playlist
                {
                    PlaylistId = 5,
                    Name = "90’s Music"
                },
                new Playlist
                {
                    PlaylistId = 6,
                    Name = "Audiobooks"
                },
                new Playlist
                {
                    PlaylistId = 7,
                    Name = "Movies"
                },
                new Playlist
                {
                    PlaylistId = 8,
                    Name = "Music"
                },
                new Playlist
                {
                    PlaylistId = 9,
                    Name = "Music Videos"
                },
                new Playlist
                {
                    PlaylistId = 10,
                    Name = "TV Shows"
                },
                new Playlist
                {
                    PlaylistId = 11,
                    Name = "Brazilian Music"
                },
                new Playlist
                {
                    PlaylistId = 12,
                    Name = "Classical"
                },
                new Playlist
                {
                    PlaylistId = 13,
                    Name = "Classical 101 - Deep Cuts"
                },
                new Playlist
                {
                    PlaylistId = 14,
                    Name = "Classical 101 - Next Steps"
                },
                new Playlist
                {
                    PlaylistId = 15,
                    Name = "Classical 101 - The Basics"
                },
                new Playlist
                {
                    PlaylistId = 16,
                    Name = "Grunge"
                },
                new Playlist
                {
                    PlaylistId = 17,
                    Name = "Heavy Metal Classic"
                },
                new Playlist
                {
                    PlaylistId = 18,
                    Name = "On-The-Go 1"
                }
            );
        }
    }
}