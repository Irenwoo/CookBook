using CookBook.Domain.Entities;
using CookBook.ValueObjects.Validators;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CookBook.Infrastructure.Configurations;

public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
{
    public void Configure(EntityTypeBuilder<Recipe> builder)
    {
        builder.ToTable("recipes");

        builder.HasKey(r => r.Id);

        builder.Property(r => r.Id)
            .HasColumnName("id")
            .IsRequired();

        builder.Property(r => r.Uuid)
            .HasColumnName("uuid")
            .IsRequired();

        builder.Property(r => r.ChefId)
            .HasColumnName("chef_id")
            .IsRequired();

        builder.Property(r => r.Title)
            .HasColumnName("title")
            .IsRequired()
            .HasConversion(title => title, str => str)
            .HasMaxLength(TitleValidator.MAX_LENGTH);

        builder.Property(r => r.Description)
            .HasColumnName("description");

        builder.Property(r => r.CookingTime)
            .HasColumnName("cooking_time");

        builder.Property(r => r.Servings)
            .HasColumnName("servings");

        builder.Property(r => r.Instructions)
            .HasColumnName("instructions")
            .IsRequired();

        builder.Property(r => r.Status)
            .HasColumnName("status")
            .HasMaxLength(20)
            .HasConversion<string>()
            .IsRequired();

        builder.Property(r => r.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired()
            .HasConversion(
                src => src.Kind == DateTimeKind.Utc ? src : DateTime.SpecifyKind(src, DateTimeKind.Utc),
                dst => dst.Kind == DateTimeKind.Utc ? dst : DateTime.SpecifyKind(dst, DateTimeKind.Utc)
            );

        builder.Property(r => r.UpdatedAt)
            .HasColumnName("updated_at")
            .IsRequired()
            .HasConversion(
                src => src.Kind == DateTimeKind.Utc ? src : DateTime.SpecifyKind(src, DateTimeKind.Utc),
                dst => dst.Kind == DateTimeKind.Utc ? dst : DateTime.SpecifyKind(dst, DateTimeKind.Utc)
            );

        builder.Property(r => r.PublishedAt)
            .HasColumnName("published_at")
            .HasConversion(
                src => !src.HasValue ? src : src.Value.Kind == DateTimeKind.Utc ? src : DateTime.SpecifyKind(src.Value, DateTimeKind.Utc),
                dst => !dst.HasValue ? dst : dst.Value.Kind == DateTimeKind.Utc ? dst : DateTime.SpecifyKind(dst.Value, DateTimeKind.Utc)
            );

        builder.HasMany(r => r.Ingredients)
            .WithOne(i => i.Recipe)
            .HasForeignKey(i => i.RecipeId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(r => r.Photos)
            .WithOne(p => p.Recipe)
            .HasForeignKey(p => p.RecipeId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(r => r.Favorites)
            .WithOne(f => f.Recipe)
            .HasForeignKey(f => f.RecipeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(r => r.Ratings)
            .WithOne(r => r.Recipe)
            .HasForeignKey(r => r.RecipeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(r => r.Comments)
            .WithOne(c => c.Recipe)
            .HasForeignKey(c => c.RecipeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}