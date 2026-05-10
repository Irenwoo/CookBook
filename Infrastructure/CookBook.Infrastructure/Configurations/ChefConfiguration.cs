using CookBook.Domain.Entities;
using CookBook.ValueObjects;
using CookBook.ValueObjects.Validators;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CookBook.Infrastructure.Configurations;

public class ChefConfiguration : IEntityTypeConfiguration<Chef>
{
    public void Configure(EntityTypeBuilder<Chef> builder)
    {
        builder.ToTable("chefs");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .HasColumnName("id")
            .IsRequired();

        builder.Property(c => c.Uuid)
            .HasColumnName("uuid")
            .IsRequired();

        builder.Property(c => c.Username)
            .HasColumnName("username")
            .IsRequired()
            .HasConversion(username => username, str => str)
            .HasMaxLength(UsernameValidator.MAX_LENGTH);

        builder.Property(c => c.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired()
            .HasConversion(
                src => src.Kind == DateTimeKind.Utc ? src : DateTime.SpecifyKind(src, DateTimeKind.Utc),
                dst => dst.Kind == DateTimeKind.Utc ? dst : DateTime.SpecifyKind(dst, DateTimeKind.Utc)
            );

        builder.HasMany(c => c.Recipes)
            .WithOne(r => r.Chef)
            .HasForeignKey(r => r.ChefId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}