using EFQ.Web.Entities;
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

            builder.Property(e => e.BaseTableName)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(e => e.StoredQueryJson)
                .IsRequired()
                .HasMaxLength(200);

            seedData(builder);
        }

        private void seedData(EntityTypeBuilder<StoredQuery> builder)
        {
            builder.HasData(
                new StoredQuery
                {
                    StoredQueryId = 1,
                    Name = "Iron Maiden Albums",
                    Description = "Albums by Iron Maiden",
                    BaseTableName = "Album",
                    StoredQueryJson = "{\"SelectionComparison\":\"Equal\",\"FieldName\":\"ArtistId\",\"RightHandSide\":{\"SelectionComparison\":\"Constant\",\"ConstantValue\":\"90\",\"AggregateList\":[]},\"AggregateList\":[]}"
                },
                new StoredQuery
                {
                    StoredQueryId = 2,
                    Name = "Led Zeppelin",
                    Description = "Albums by Led Zeppelin",
                    BaseTableName = "Album",
                    StoredQueryJson = "{\"SelectionComparison\":\"Equal\",\"FieldName\":\"ArtistId\",\"RightHandSide\":{\"SelectionComparison\":\"Constant\",\"ConstantValue\":\"22\",\"AggregateList\":[]},\"AggregateList\":[]}"
                });
        }
    }
}
