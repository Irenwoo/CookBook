using CookBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CookBook.Infrastructure.Configurations;

public class FavoriteConfiguration : IEntityTypeConfiguration<Favorite>
{
    public void Configure(EntityTypeBuilder<Favorite> builder)
    {
        builder.ToTable("favorites");

        builder.HasKey(f => f.Id);

        builder.Property(f => f.Id)
            .HasColumnName("id")
            .IsRequired();

        builder.Property(f => f.GourmetId)
            .HasColumnName("gourmet_id")
            .IsRequired();

        builder.Property(f => f.RecipeId)
            .HasColumnName("recipe_id")
            .IsRequired();

        builder.Property(f => f.CreatedAt)
            .HasColumnName("created_at");

        builder.HasIndex(f => new { f.GourmetId, f.RecipeId })
            .IsUnique();
    }
}
