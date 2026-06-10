using MeroBriksha.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeroBriksha.Data.Configurations;

public class DonationConfiguration : IEntityTypeConfiguration<Donation>
{
    // IMPORTANT:
    // Entity properties in this project use UPPERCASE names to align with database columns
    // such as DONORID and CAMPAIGNID. EF Core may sometimes infer relationships by
    // convention, but relying on convention with custom naming can be risky.
    //
    // Therefore, relationships are configured explicitly using HasForeignKey.
    // This ensures that:
    // - Donation.DONORID is used as the foreign key for Donation.Donor
    // - Donation.CAMPAIGNID is used as the foreign key for Donation.Campaign
    // - EF Core does not create unexpected shadow foreign key columns
    // - Include(x => x.Donor) and Include(x => x.Campaign) use the intended columns
    public void Configure(EntityTypeBuilder<Donation> builder)
    {
        builder.ToTable("Donations");

        builder.HasKey(x => x.ID);

        builder.Property(x => x.ID)
            .HasColumnName("ID")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.DONORID)
            .HasColumnName("DONORID")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.CAMPAIGNID)
            .HasColumnName("CAMPAIGNID")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.AMOUNT)
            .HasColumnName("AMOUNT")
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(x => x.STATUS)
            .HasColumnName("STATUS")
            .HasConversion<int>()
            .IsRequired();

        builder.Property(x => x.PAYMENTREFERENCE)
            .HasColumnName("PAYMENTREFERENCE")
            .HasMaxLength(100);

        builder.Property(x => x.REMARKS)
            .HasColumnName("REMARKS")
            .HasMaxLength(500);

        builder.Property(x => x.CREATEDDATE)
            .HasColumnName("CREATEDDATE")
            .HasDefaultValueSql("GETUTCDATE()")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.VERIFIEDDATE)
            .HasColumnName("VERIFIEDDATE");

        builder.HasOne(x => x.Donor)
            .WithMany()
            .HasForeignKey(x => x.DONORID)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Campaign)
            .WithMany()
            .HasForeignKey(x => x.CAMPAIGNID)
            .OnDelete(DeleteBehavior.Restrict);
    }
}