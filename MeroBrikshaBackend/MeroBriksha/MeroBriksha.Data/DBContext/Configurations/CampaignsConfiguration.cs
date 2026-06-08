using MeroBriksha.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeroBriksha.Data.DBContext.Configurations
{
    internal class CampaignsConfiguration : IEntityTypeConfiguration<Core.Entities.Campaign>
    {
        public void Configure(EntityTypeBuilder<Campaign> builder)
        {
            builder.ToTable("Campaigns");

            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.NAME)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.DESCRIPTION)
                .HasMaxLength(2000);

            builder.Property(x => x.ORGANIZERNAME)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(x => x.STARTDATEUTC)
                .IsRequired();

            builder.Property(x => x.ENDDATEUTC);

            builder.Property(x => x.TARGETTREECOUNT);

            builder.Property(x => x.CREATEDDATE)
               .IsRequired()
               .HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
