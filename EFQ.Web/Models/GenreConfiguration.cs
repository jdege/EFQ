using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFQ.Web.Models
{
    internal class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable("Genre");

            builder.Property(e => e.Name).HasMaxLength(120);

            seedData(builder);
        }
        private void seedData(EntityTypeBuilder<Genre> builder)
        {
            builder.HasData(
                new Genre
                {
                    GenreId = 1,
                    Name = "Rock"
                },
                new Genre
                {
                    GenreId = 2,
                    Name = "Jazz"
                },
                new Genre
                {
                    GenreId = 3,
                    Name = "Metal"
                },
                new Genre
                {
                    GenreId = 4,
                    Name = "Alternative & Punk"
                },
                new Genre
                {
                    GenreId = 5,
                    Name = "Rock And Roll"
                },
                new Genre
                {
                    GenreId = 6,
                    Name = "Blues"
                },
                new Genre
                {
                    GenreId = 7,
                    Name = "Latin"
                },
                new Genre
                {
                    GenreId = 8,
                    Name = "Reggae"
                },
                new Genre
                {
                    GenreId = 9,
                    Name = "Pop"
                },
                new Genre
                {
                    GenreId = 10,
                    Name = "Soundtrack"
                },
                new Genre
                {
                    GenreId = 11,
                    Name = "Bossa Nova"
                },
                new Genre
                {
                    GenreId = 12,
                    Name = "Easy Listening"
                },
                new Genre
                {
                    GenreId = 13,
                    Name = "Heavy Metal"
                },
                new Genre
                {
                    GenreId = 14,
                    Name = "R&B/Soul"
                },
                new Genre
                {
                    GenreId = 15,
                    Name = "Electronica/Dance"
                },
                new Genre
                {
                    GenreId = 16,
                    Name = "World"
                },
                new Genre
                {
                    GenreId = 17,
                    Name = "Hip Hop/Rap"
                },
                new Genre
                {
                    GenreId = 18,
                    Name = "Science Fiction"
                },
                new Genre
                {
                    GenreId = 19,
                    Name = "TV Shows"
                },
                new Genre
                {
                    GenreId = 20,
                    Name = "Sci Fi & Fantasy"
                },
                new Genre
                {
                    GenreId = 21,
                    Name = "Drama"
                },
                new Genre
                {
                    GenreId = 22,
                    Name = "Comedy"
                },
                new Genre
                {
                    GenreId = 23,
                    Name = "Alternative"
                },
                new Genre
                {
                    GenreId = 24,
                    Name = "Classical"
                },
                new Genre
                {
                    GenreId = 25,
                    Name = "Opera"
                }
            );
        }
    }
}