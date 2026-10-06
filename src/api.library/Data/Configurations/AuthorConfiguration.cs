using api.library.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.library.Data.Configurations;

public class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.ToTable("Authors");

        builder.HasKey(a => a.Id);
        builder.Property(a => a.Id).UseIdentityColumn();

        builder.Property(a => a.FirstName)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(a => a.LastName)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(a => a.Nationality)
            .HasMaxLength(50);

        builder.Property(a => a.BirthDate)
            .IsRequired(false);

        builder.Property(a => a.Biography)
            .HasMaxLength(1000);

        builder.HasMany(a => a.Books)
            .WithMany(b => b.Authors)
            .UsingEntity<Dictionary<string, object>>("BookAuthor");

    }
}