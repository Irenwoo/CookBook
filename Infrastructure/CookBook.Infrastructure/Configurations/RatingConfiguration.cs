using CookBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CookBook.Infrastructure.Configurations;

public class RatingConfiguration : IEntityTypeConfiguration<Rating>
{
    public void Configure(EntityTypeBuilder<Rating> builder)
    {
        builder.ToTable("ratings");

        builder.HasKey(r => r.Id);

        builder.Property(r => r.Id)
            .HasColumnName("id")
            .IsRequired();

        builder.Property(r => r.GourmetId)
            .HasColumnName("gourmet_id")
            .IsRequired();

        builder.Property(r => r.RecipeId)
            .HasColumnName("recipe_id")
            .IsRequired();

        builder.Property(r => r.Score)
            .HasColumnName("score")
            .IsRequired();

        builder.Property(r => r.CreatedAt)
            .HasColumnName("created_at");

        builder.Property(r => r.UpdatedAt)
            .HasColumnName("updated_at");

        builder.HasIndex(r => new { r.GourmetId, r.RecipeId })
            .IsUnique();
    }
}
