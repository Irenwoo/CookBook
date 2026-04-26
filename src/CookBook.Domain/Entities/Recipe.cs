using CookBook.Domain.Base;

namespace CookBook.Domain.Entities;

public class Recipe : BaseEntity
{
    public Guid ChefId { get; private set; }
    public string Title { get; private set; }
    public string? Description { get; private set; }
    public int? CookingTime { get; private set; }
    public int? Servings { get; private set; }
    public string Instructions { get; private set; }
    public RecipeStatus Status { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    public DateTime? PublishedAt { get; private set; }

    public Chef? Chef { get; private set; }

    private readonly List<Ingredient> _ingredients = new();
    public IReadOnlyCollection<Ingredient> Ingredients => _ingredients.AsReadOnly();

    private readonly List<Photo> _photos = new();
    public IReadOnlyCollection<Photo> Photos => _photos.AsReadOnly();

    private readonly List<Favorite> _favorites = new();
    public IReadOnlyCollection<Favorite> Favorites => _favorites.AsReadOnly();

    private readonly List<Rating> _ratings = new();
    public IReadOnlyCollection<Rating> Ratings => _ratings.AsReadOnly();

    private readonly List<Comment> _comments = new();
    public IReadOnlyCollection<Comment> Comments => _comments.AsReadOnly();

    private Recipe() : base() { }

    private Recipe(Guid id, Guid uuid, Guid chefId, string title, string? description,
        int? cookingTime, int? servings, string instructions, RecipeStatus status,
        DateTime createdAt, DateTime updatedAt, DateTime? publishedAt)
        : base(id, uuid)
    {
        ChefId = chefId;
        Title = title;
        Description = description;
        CookingTime = cookingTime;
        Servings = servings;
        Instructions = instructions;
        Status = status;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        PublishedAt = publishedAt;
    }

    public static Recipe Create(Guid chefId, string title, string instructions,
        string? description = null, int? cookingTime = null, int? servings = null)
    {
        if (chefId == Guid.Empty)
            throw new ArgumentException("Идентификатор шефа не может быть пустым.", nameof(chefId));

        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Заголовок не может быть пустым.", nameof(title));

        if (title.Length > 100)
            throw new ArgumentException("Длина заголовка не должна превышать 100 символов.", nameof(title));

        if (string.IsNullOrWhiteSpace(instructions))
            throw new ArgumentException("Инструкции не могут быть пустыми.", nameof(instructions));

        var now = DateTime.UtcNow;
        return new Recipe(Guid.NewGuid(), Guid.NewGuid(), chefId, title, description,
            cookingTime, servings, instructions, RecipeStatus.Draft, now, now, null);
    }

    public static Recipe Restore(Guid id, Guid uuid, Guid chefId, string title, string? description,
        int? cookingTime, int? servings, string instructions, RecipeStatus status,
        DateTime createdAt, DateTime updatedAt, DateTime? publishedAt)
        => new Recipe(id, uuid, chefId, title, description, cookingTime, servings,
            instructions, status, createdAt, updatedAt, publishedAt);

    public void Update(string title, string instructions, string? description = null,
        int? cookingTime = null, int? servings = null)
    {
        if (Status == RecipeStatus.Archived)
            throw new InvalidOperationException("");

        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Не удается обновить архивированный рецепт.", nameof(title));

        if (title.Length > 100)
            throw new ArgumentException("Длина заголовка не должна превышать 100 символов.", nameof(title));

        if (string.IsNullOrWhiteSpace(instructions))
            throw new ArgumentException("Инструкции не могут быть пустыми.", nameof(instructions));

        Title = title;
        Instructions = instructions;
        Description = description;
        CookingTime = cookingTime;
        Servings = servings;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Publish()
    {
        if (Status != RecipeStatus.Draft)
            throw new InvalidOperationException("Публиковать можно только черновые рецепты.");

        Status = RecipeStatus.Published;
        PublishedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Archive()
    {
        if (Status == RecipeStatus.Archived)
            throw new InvalidOperationException("Рецепт уже заархивирован.");

        Status = RecipeStatus.Archived;
        UpdatedAt = DateTime.UtcNow;
    }
}
