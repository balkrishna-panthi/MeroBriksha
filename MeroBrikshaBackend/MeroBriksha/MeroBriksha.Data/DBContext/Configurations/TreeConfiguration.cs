using MeroBriksha.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeroBriksha.Data.DBContext.Configurations;

public class TreeConfiguration : IEntityTypeConfiguration<Tree>
{
    public void Configure(EntityTypeBuilder<Tree> builder)
    {
        builder.ToTable("Trees");

        builder.HasKey(x => x.ID);


        builder.Property(x => x.ID)
            .HasColumnName("ID")
            .HasMaxLength(50)
            .IsRequired();


        builder.Property(x => x.TREEASSIGNMENTID)
            .HasColumnName("TREEASSIGNMENTID")
            .HasMaxLength(50)
            .IsRequired();


        builder.Property(x => x.PLANTID)
            .HasColumnName("PLANTID")
            .HasMaxLength(50)
            .IsRequired();


        builder.Property(x => x.ADDRESS)
            .HasColumnName("ADDRESS")
            .HasMaxLength(500);


        builder.Property(x => x.LOCATIONLINK)
            .HasColumnName("LOCATIONLINK")
            .HasMaxLength(1000);


        builder.Property(x => x.LATITUDE)
            .HasColumnName("LATITUDE")
            .HasPrecision(10, 7);


        builder.Property(x => x.LONGITUDE)
            .HasColumnName("LONGITUDE")
            .HasPrecision(10, 7);


        builder.Property(x => x.PLANTEDDATE)
            .HasColumnName("PLANTEDDATE")
            .IsRequired();


        builder.Property(x => x.STATUS)
            .HasColumnName("STATUS")
            .HasConversion<int>()
            .IsRequired();


        builder.Property(x => x.TRACKINGCODE)
            .HasColumnName("TRACKINGCODE")
            .HasMaxLength(50)
            .IsRequired();


        // IMPORTANT:
        // Tracking code is the public identity of a tree.
        // Two physical trees should never have the same tracking code.
        builder.HasIndex(x => x.TRACKINGCODE)
            .IsUnique();


        builder.Property(x => x.CREATEDDATE)
            .HasColumnName("CREATEDDATE")
            .HasDefaultValueSql("GETUTCDATE()")
            .ValueGeneratedOnAdd();



        // IMPORTANT:
        // A Tree belongs to one TreeAssignment.
        //
        // Workflow:
        //
        // Donation
        //     |
        // TreeAssignment (Pending)
        //     |
        // Tree (created after plantation)
        //
        // TreeAssignment can exist without a Tree,
        // but a Tree cannot exist without a TreeAssignment.
        builder.HasOne(x => x.TreeAssignment)
            .WithOne()
            .HasForeignKey<Tree>(x => x.TREEASSIGNMENTID)
            .OnDelete(DeleteBehavior.Restrict);



        // IMPORTANT:
        // Many Trees can belong to one Plant species.
        //
        // Example:
        //
        // Plant
        //  |
        //  |---- Tree 1 (Mango)
        //  |---- Tree 2 (Mango)
        //  |---- Tree 3 (Mango)
        //
        builder.HasOne<Plant>()
            .WithMany()
            .HasForeignKey(x => x.PLANTID)
            .OnDelete(DeleteBehavior.Restrict);
    }
}