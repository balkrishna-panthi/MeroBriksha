using MeroBriksha.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeroBriksha.Data.DBContext.Configurations
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.ToTable("Locations");

            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID)
                .HasColumnName("ID")
                .HasMaxLength(50)
                .IsRequired();

            // Example string properties
            builder.Property(x => x.ADDRESS)
                .HasColumnName("ADDRESS")
                .HasMaxLength(200);

            builder.Property(x => x.LOCATIONLINK)
                .HasColumnName("LOCATIONLINK")
                .HasMaxLength(500);

            // Example coordinates - adjust types and precision to match your entity
            builder.Property(x => x.LATITUDE)
                .HasColumnName("LATITUDE")
                .HasColumnType("decimal(9,6)");

            builder.Property(x => x.LONGITUDE)
                .HasColumnName("LONGITUDE")
                .HasColumnType("decimal(9,6)");

            // CREATEDDATE with default like other entities
            builder.Property(x => x.CREATEDDATE)
                .HasColumnName("CREATEDDATE")
                .HasDefaultValueSql("GETUTCDATE()")
                .ValueGeneratedOnAdd();

            // TODO: add .IsRequired() where appropriate and configure any FKs/relationships.
        }
    }
}