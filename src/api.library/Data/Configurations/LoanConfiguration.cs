using api.library.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.library.Data.Configurations;

public class LoanConfiguration : IEntityTypeConfiguration<Loan>
{
    public void Configure(EntityTypeBuilder<Loan> builder)
    {
        builder.ToTable("Loans");

        builder.HasKey(l => l.Id);
        builder.Property(l => l.Id).UseIdentityColumn();

        builder.Property(l => l.BookId)
            .IsRequired();

        builder.HasOne(l => l.Book)
            .WithMany()
            .HasForeignKey(l => l.BookId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(l => l.MemberId)
            .IsRequired();

        builder.HasOne(l => l.Member)
            .WithMany()
            .HasForeignKey(l => l.MemberId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(l => l.LoanDate)
            .IsRequired();

        builder.Property(l => l.DueDate)
            .IsRequired();

        builder.Property(l => l.Status)
            .HasConversion<int>();
    }
}