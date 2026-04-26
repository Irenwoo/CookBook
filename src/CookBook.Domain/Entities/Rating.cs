namespace CookBook.Domain.Entities;

public class Rating
{
    public Guid Id { get; private set; }
    public Guid GourmetId { get; private set; }
    public Guid RecipeId { get; private set; }
    public int Score { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    public Gourmet? Gourmet { get; private set; }
    public Recipe? Recipe { get; private set; }

    private Rating() { }

    private Rating(Guid id, Guid gourmetId, Guid recipeId, int score, DateTime createdAt, DateTime updatedAt)
    {
        Id = id;
        GourmetId = gourmetId;
        RecipeId = recipeId;
        Score = score;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public static Rating Create(Guid gourmetId, Guid recipeId, int score)
    {
        if (gourmetId == Guid.Empty)
            throw new ArgumentException("Гурман не может быть пустым.", nameof(gourmetId));

        if (recipeId == Guid.Empty)
            throw new ArgumentException("Идентификатор рецепта не может быть пустым.", nameof(recipeId));

        ValidateScore(score);

        var now = DateTime.UtcNow;
        return new Rating(Guid.NewGuid(), gourmetId, recipeId, score, now, now);
    }

    public static Rating Restore(Guid id, Guid gourmetId, Guid recipeId, int score, DateTime createdAt, DateTime updatedAt)
        => new Rating(id, gourmetId, recipeId, score, createdAt, updatedAt);

    public void UpdateScore(int score)
    {
        ValidateScore(score);
        Score = score;
        UpdatedAt = DateTime.UtcNow;
    }

    private static void ValidateScore(int score)
    {
        if (score < 1 || score > 5)
            throw new ArgumentException("Оценка должна быть от 1 до 5.", nameof(score));
    }
}
