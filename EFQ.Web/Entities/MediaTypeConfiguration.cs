using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JDege.EFQ.Web.Entities
{
    internal class MediaTypeConfiguration : IEntityTypeConfiguration<MediaType>
    {
        public void Configure(EntityTypeBuilder<MediaType> builder)
        {
            builder.ToTable("MediaType");

            builder.Property(e => e.Name).HasMaxLength(120);

            seedData(builder);
        }
        private void seedData(EntityTypeBuilder<MediaType> builder)
        {
            builder.HasData(
                new MediaType
                {
                    MediaTypeId = 1,
                    Name = "MPEG audio file"
                },
                new MediaType
                {
                    MediaTypeId = 2,
                    Name = "Protected AAC audio file"
                },
                new MediaType
                {
                    MediaTypeId = 3,
                    Name = "Protected MPEG-4 video file"
                },
                new MediaType
                {
                    MediaTypeId = 4,
                    Name = "Purchased AAC audio file"
                },
                new MediaType
                {
                    MediaTypeId = 5,
                    Name = "AAC audio file"
                }
            );
        }
    }
}