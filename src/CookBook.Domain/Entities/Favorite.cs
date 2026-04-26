namespace CookBook.Domain.Entities;

public class Favorite
{
    public Guid Id { get; private set; }
    public Guid GourmetId { get; private set; }
    public Guid RecipeId { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public Gourmet? Gourmet { get; private set; }
    public Recipe? Recipe { get; private set; }

    private Favorite() { }

    private Favorite(Guid id, Guid gourmetId, Guid recipeId, DateTime createdAt)
    {
        Id = id;
        GourmetId = gourmetId;
        RecipeId = recipeId;
        CreatedAt = createdAt;
    }

    public static Favorite Create(Guid gourmetId, Guid recipeId)
    {
        if (gourmetId == Guid.Empty)
            throw new ArgumentException("Гурман не может быть пустым.", nameof(gourmetId));

        if (recipeId == Guid.Empty)
            throw new ArgumentException("Идентификатор рецепта не может быть пустым.", nameof(recipeId));

        return new Favorite(Guid.NewGuid(), gourmetId, recipeId, DateTime.UtcNow);
    }

    public static Favorite Restore(Guid id, Guid gourmetId, Guid recipeId, DateTime createdAt)
        => new Favorite(id, gourmetId, recipeId, createdAt);
}
