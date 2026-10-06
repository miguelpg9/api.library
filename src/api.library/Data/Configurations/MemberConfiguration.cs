using api.library.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.library.Data.Configurations;

public class MemberConfiguration : IEntityTypeConfiguration<Member>
{
    public void Configure(EntityTypeBuilder<Member> builder)
    {
        builder.ToTable("Members");

        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id).UseIdentityColumn();

        builder.Property(m => m.FirstName)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(m => m.LastName)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(m => m.Email)
            .HasMaxLength(100)
            .IsRequired();

        builder.HasIndex(m => m.Email)
            .IsUnique();

        builder.Property(m => m.Phone)
            .HasMaxLength(20);

        builder.Property(m => m.MembershipDate)
            .IsRequired();

        builder.Property(m => m.IsActive)
            .HasDefaultValue(true);
    }
}