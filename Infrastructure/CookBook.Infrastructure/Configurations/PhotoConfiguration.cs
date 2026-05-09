using CookBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CookBook.Infrastructure.Configurations;

public class PhotoConfiguration : IEntityTypeConfiguration<Photo>
{
    public void Configure(EntityTypeBuilder<Photo> builder)
    {
        builder.ToTable("photos");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .HasColumnName("id")
            .IsRequired();

        builder.Property(p => p.Uuid)
            .HasColumnName("uuid")
            .IsRequired();

        builder.Property(p => p.RecipeId)
            .HasColumnName("recipe_id")
            .IsRequired();

        builder.Property(p => p.Url)
            .HasColumnName("url")
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(p => p.IsMain)
            .HasColumnName("is_main");
    }
}
