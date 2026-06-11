using MeroBriksha.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeroBriksha.Data.Configurations;

public class TreeAssignmentConfiguration : IEntityTypeConfiguration<TreeAssignment>
{
    public void Configure(EntityTypeBuilder<TreeAssignment> builder)
    {
        builder.ToTable("TreeAssignments");

        builder.HasKey(x => x.ID);

        builder.Property(x => x.ID)
            .HasColumnName("ID")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.DONATIONID)
            .HasColumnName("DONATIONID")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.STATUS)
            .HasColumnName("STATUS")
            .HasConversion<int>()
            .IsRequired();

        builder.Property(x => x.REMARKS)
            .HasColumnName("REMARKS")
            .HasMaxLength(500);

        builder.Property(x => x.CREATEDDATE)
            .HasColumnName("CREATEDDATE")
            .HasDefaultValueSql("GETUTCDATE()")
            .ValueGeneratedOnAdd();

        // IMPORTANT:
        // Explicit FK configuration is used because entity/database-facing properties
        // follow UPPERCASE naming. This avoids EF Core convention ambiguity and prevents
        // unintended shadow FK columns. Include(...) will use this configured relationship.
        builder.HasOne(x => x.Donation) //has one donation,
             .WithMany()               //but a donation can have many tree assignments. This is a one-to-many relationship.
            .HasForeignKey(x => x.DONATIONID)
            .OnDelete(DeleteBehavior.Restrict); //This means if a donation already has tree assignments,
                                                //deleting that donation should not automatically delete
                                                //the tree assignment history.
    }
}