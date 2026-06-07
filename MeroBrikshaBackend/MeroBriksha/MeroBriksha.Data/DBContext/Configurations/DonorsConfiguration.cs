using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeroBriksha.Data.DBContext.Configurations
{
    public class DonorsConfiguration : IEntityTypeConfiguration<Core.Entities.Donor>
    {
        public void Configure(EntityTypeBuilder<Core.Entities.Donor> builder)
        {
            builder.ToTable("Donors");

            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.FULLNAME)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(x => x.EMAIL)
                .HasMaxLength(150);

            builder.Property(x => x.PHONENUMBER)
                .HasMaxLength(30);

            builder.Property(x => x.ADDRESS)
                .HasMaxLength(300);

            builder.Property(x => x.CREATEDDATE)
               .IsRequired()
               .HasDefaultValueSql("GETUTCDATE()");
        }

    }
}
