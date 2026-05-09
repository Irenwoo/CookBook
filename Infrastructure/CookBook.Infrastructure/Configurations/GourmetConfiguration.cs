using CookBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CookBook.Infrastructure.Configurations;

public class GourmetConfiguration : IEntityTypeConfiguration<Gourmet>
{
    public void Configure(EntityTypeBuilder<Gourmet> builder)
    {
        builder.ToTable("gourmets");

        builder.HasKey(g => g.Id);

        builder.Property(g => g.Id)
            .HasColumnName("id")
            .IsRequired();

        builder.Property(g => g.Uuid)
            .HasColumnName("uuid")
            .IsRequired();

        builder.Property(g => g.Username)
            .HasColumnName("username")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(g => g.CreatedAt)
            .HasColumnName("created_at");

        builder.HasMany(g => g.Favorites)
            .WithOne(f => f.Gourmet)
            .HasForeignKey(f => f.GourmetId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(g => g.Ratings)
            .WithOne(r => r.Gourmet)
            .HasForeignKey(r => r.GourmetId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(g => g.Comments)
            .WithOne(c => c.Gourmet)
            .HasForeignKey(c => c.GourmetId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
