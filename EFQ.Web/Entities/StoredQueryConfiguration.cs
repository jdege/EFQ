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
                    Name = "Search for Album",
                    Description = "EFQBuilder.Equal(\"AlbumId\", 1)",
                    StoredQueryJson = "{\"EFQType\":\"Equal\",\"FieldName\":\"AlbumId\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"FieldName\":null,\"RightHandSide\":null,\"ConstantString\":null,\"ConstantInt\":1,\"ConstantDouble\":null,\"ConstantDecimal\":null,\"ConstantDateTime\":null,\"ConstantDateTimeOffset\":null,\"InnerCriteria\":null,\"AggregateList\":[]},\"ConstantString\":null,\"ConstantInt\":null,\"ConstantDouble\":null,\"ConstantDecimal\":null,\"ConstantDateTime\":null,\"ConstantDateTimeOffset\":null,\"InnerCriteria\":null,\"AggregateList\":[]}"
                },
                new StoredQuery
                {
                    StoredQueryId = 2,
                    Name = "Search for Artist",
                    Description = "EFQBuilder.Equal(\"Album.ArtistId\", 1)",
                    StoredQueryJson = "{\"EFQType\":\"Equal\",\"FieldName\":\"Album.ArtistId\",\"RightHandSide\":{\"EFQType\":\"Constant\",\"FieldName\":null,\"RightHandSide\":null,\"ConstantString\":null,\"ConstantInt\":1,\"ConstantDouble\":null,\"ConstantDecimal\":null,\"ConstantDateTime\":null,\"ConstantDateTimeOffset\":null,\"InnerCriteria\":null,\"AggregateList\":[]},\"ConstantString\":null,\"ConstantInt\":null,\"ConstantDouble\":null,\"ConstantDecimal\":null,\"ConstantDateTime\":null,\"ConstantDateTimeOffset\":null,\"InnerCriteria\":null,\"AggregateList\":[]}"
                }
            );
        }
    }
}
