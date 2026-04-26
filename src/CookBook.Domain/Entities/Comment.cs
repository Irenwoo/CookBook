using CookBook.Domain.Base;

namespace CookBook.Domain.Entities;

public class Comment : BaseEntity
{
    public Guid GourmetId { get; private set; }
    public Guid RecipeId { get; private set; }
    public string Content { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    public Gourmet? Gourmet { get; private set; }
    public Recipe? Recipe { get; private set; }

    private Comment() : base() { }

    private Comment(Guid id, Guid uuid, Guid gourmetId, Guid recipeId, string content,
        DateTime createdAt, DateTime updatedAt)
        : base(id, uuid)
    {
        GourmetId = gourmetId;
        RecipeId = recipeId;
        Content = content;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public static Comment Create(Guid gourmetId, Guid recipeId, string content)
    {
        if (gourmetId == Guid.Empty)
            throw new ArgumentException("Гурман не может быть пустым.", nameof(gourmetId));

        if (recipeId == Guid.Empty)
            throw new ArgumentException("Идентификатор рецепта не может быть пустым.", nameof(recipeId));

        if (string.IsNullOrWhiteSpace(content))
            throw new ArgumentException("Содержимое не может быть пустым", nameof(content));

        var now = DateTime.UtcNow;
        return new Comment(Guid.NewGuid(), Guid.NewGuid(), gourmetId, recipeId, content, now, now);
    }

    public static Comment Restore(Guid id, Guid uuid, Guid gourmetId, Guid recipeId,
        string content, DateTime createdAt, DateTime updatedAt)
        => new Comment(id, uuid, gourmetId, recipeId, content, createdAt, updatedAt);

    public void Edit(string content)
    {
        if (string.IsNullOrWhiteSpace(content))
            throw new ArgumentException("Содержимое не может быть пустым", nameof(content));

        Content = content;
        UpdatedAt = DateTime.UtcNow;
    }
}
