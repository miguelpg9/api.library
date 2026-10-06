using api.library.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.library.Data.Configurations;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable("Books", t =>
        {
            t.HasCheckConstraint(
                "CK_Books_Quantity_NonNegative",
                "\"Quantity\" >= 0"
            );

            t.HasCheckConstraint(
                "CK_Books_PublicationYear_Min",
                "\"PublicationYear\" >= 1000"
            );
        });

        builder.HasKey(b => b.Id);
        builder.Property(b => b.Id).UseIdentityColumn();

        builder.Property(b => b.Title)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(b => b.Isbn)
            .HasMaxLength(17)
            .IsRequired();

        builder.HasIndex(b => b.Isbn)
            .IsUnique();

        builder.Property(b => b.PublicationYear)
            .IsRequired();

        builder.Property(b => b.Publisher)
            .HasMaxLength(100);

        builder.Property(b => b.Genre)
            .HasMaxLength(50);

        builder.Property(b => b.Quantity)
            .IsRequired();

        builder.HasMany(b => b.Authors)
            .WithMany(a => a.Books)
            .UsingEntity<Dictionary<string, object>>("BookAuthor");

    }

}