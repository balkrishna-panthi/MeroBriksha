using MeroBriksha.Core;
using MeroBriksha.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeroBriksha.Data.Configurations
{
    public class PlantConfiguration : IEntityTypeConfiguration<Core.Entities.Plant>
    {
        public void Configure(EntityTypeBuilder<Core.Entities.Plant> builder)
        {
            builder.ToTable("Plants");

            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.NAME)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.SCIENTIFICNAME)
                .HasMaxLength(150);

            builder.Property(x => x.DESCRIPTION)
                .HasMaxLength(500);
        }
    }
}