using CookBook.Domain.Base;

namespace CookBook.Domain.Entities;

public class Photo : Entity<Guid>
{
    public Guid RecipeId { get; private set; }
    public string Url { get; private set; }
    public bool IsMain { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public Recipe? Recipe { get; private set; }

    private Photo() : base() { }

    private Photo(Guid id, Guid recipeId, string url, bool isMain, DateTime createdAt)
        : base(id)
    {
        RecipeId = recipeId;
        Url = url;
        IsMain = isMain;
        CreatedAt = createdAt;
    }

    public static Photo Create(Guid recipeId, string url, bool isMain = false)
    {
        if (recipeId == Guid.Empty)
            throw new ArgumentException("RecipeId cannot be empty.", nameof(recipeId));
        if (string.IsNullOrWhiteSpace(url))
            throw new ArgumentException("Url cannot be empty.", nameof(url));
        return new Photo(Guid.NewGuid(), recipeId, url, isMain, DateTime.UtcNow);
    }

    public static Photo Restore(Guid id, Guid recipeId, string url, bool isMain, DateTime createdAt)
        => new Photo(id, recipeId, url, isMain, createdAt);
}