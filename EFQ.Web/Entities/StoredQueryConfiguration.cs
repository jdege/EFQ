using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFQ.Web.Entities
{
    internal class StoredQueryConfiguration : IEntityTypeConfiguration<StoredQuery>
    {
        public void Configure(EntityTypeBuilder<StoredQuery> builder)
        {
            builder.ToTable("StoredQuery");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(e => e.Description)
                .HasMaxLength(int.MaxValue);

            builder.Property(e => e.StoredQueryJson)
                .IsRequired()
                .HasMaxLength(int.MaxValue);

            seedData(builder);
        }

        private void seedData(EntityTypeBuilder<StoredQuery> builder)
        {
            builder.HasData(
                new StoredQuery
                {
                    StoredQueryId = 1,
                    Name = "Search for a Track",
                    Query = "EFQBuilder.Equal(\"TrackId\", 1)",
                    Description = "To find a given track",
                    // StoredQueryJson = "{\"EFQType\":\"Equal\",\"FieldName\":\"TrackId\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"FieldName\":null,\"RightHandSide\":null,\"ConstantString\":null,\"ConstantInt\":1,\"ConstantDouble\":null,\"ConstantDecimal\":null,\"ConstantDateTime\":null,\"ConstantDateTimeOffset\":null,\"InnerCriteria\":null,\"AggregateList\":[]},\"ConstantString\":null,\"ConstantInt\":null,\"ConstantDouble\":null,\"ConstantDecimal\":null,\"ConstantDateTime\":null,\"ConstantDateTimeOffset\":null,\"InnerCriteria\":null,\"AggregateList\":[]}"
                    StoredQueryJson = "{\"EFQType\":\"Equal\",\"FieldName\":\"TrackId\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantInt\":1,\"AggregateList\":[]},\"AggregateList\":[]}"
                },
                new StoredQuery
                {
                    StoredQueryId = 2,
                    Name = "Search by Album",
                    Query = "EFQBuilder.Equal(\"AlbumId\", 1)",
                    Description = "To find all tracks for a given album",
                    // StoredQueryJson = "{\"EFQType\":\"Equal\",\"FieldName\":\"AlbumId\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"FieldName\":null,\"RightHandSide\":null,\"ConstantString\":null,\"ConstantInt\":1,\"ConstantDouble\":null,\"ConstantDecimal\":null,\"ConstantDateTime\":null,\"ConstantDateTimeOffset\":null,\"InnerCriteria\":null,\"AggregateList\":[]},\"ConstantString\":null,\"ConstantInt\":null,\"ConstantDouble\":null,\"ConstantDecimal\":null,\"ConstantDateTime\":null,\"ConstantDateTimeOffset\":null,\"InnerCriteria\":null,\"AggregateList\":[]}"
                    StoredQueryJson = "{\"EFQType\":\"Equal\",\"FieldName\":\"AlbumId\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantInt\":1,\"AggregateList\":[]},\"AggregateList\":[]}"
                },
                new StoredQuery
                {
                    StoredQueryId = 3,
                    Name = "Search by Artist",
                    Query = "EFQBuilder.Equal(\"Album.ArtistId\", 1)",
                    Description = "To find all tracks for all albums with a given artist",
                    //StoredQueryJson = "{\"EFQType\":\"Equal\",\"FieldName\":\"Album.ArtistId\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"FieldName\":null,\"RightHandSide\":null,\"ConstantString\":null,\"ConstantInt\":1,\"ConstantDouble\":null,\"ConstantDecimal\":null,\"ConstantDateTime\":null,\"ConstantDateTimeOffset\":null,\"InnerCriteria\":null,\"AggregateList\":[]},\"ConstantString\":null,\"ConstantInt\":null,\"ConstantDouble\":null,\"ConstantDecimal\":null,\"ConstantDateTime\":null,\"ConstantDateTimeOffset\":null,\"InnerCriteria\":null,\"AggregateList\":[]}"
                    StoredQueryJson = "{\"EFQType\":\"Equal\",\"FieldName\":\"Album.ArtistId\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"ConstantInt\":1,\"AggregateList\":[]},\"AggregateList\":[]}"
                }
            );
        }
    }
}
