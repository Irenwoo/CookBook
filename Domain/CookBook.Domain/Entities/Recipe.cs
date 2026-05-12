using CookBook.Domain.Base;

namespace CookBook.Domain.Entities;

public class Recipe : Entity<Guid>
{
    public Guid ChefId { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public string Instructions { get; private set; }
    public int CookingTime { get; private set; }
    public int Servings { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    public DateTime? PublishedAt { get; private set; }
    public RecipeStatus Status { get; private set; }

    public Chef? Chef { get; private set; }

    private readonly List<Ingredient> _ingredients = new();
    public IReadOnlyCollection<Ingredient> Ingredients => _ingredients.AsReadOnly();

    private readonly List<Photo> _photos = new();
    public IReadOnlyCollection<Photo> Photos => _photos.AsReadOnly();

    private readonly List<Comment> _comments = new();
    public IReadOnlyCollection<Comment> Comments => _comments.AsReadOnly();

    private readonly List<Rating> _ratings = new();
    public IReadOnlyCollection<Rating> Ratings => _ratings.AsReadOnly();

    private readonly List<Favorite> _favorites = new();
    public IReadOnlyCollection<Favorite> Favorites => _favorites.AsReadOnly();

    private Recipe() : base() { }

    private Recipe(Guid id, Guid chefId, string title, string description, string instructions,
        int cookingTime, int servings, DateTime createdAt, DateTime updatedAt,
        DateTime? publishedAt, RecipeStatus status)
        : base(id)
    {
        ChefId = chefId;
        Title = title;
        Description = description;
        Instructions = instructions;
        CookingTime = cookingTime;
        Servings = servings;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        PublishedAt = publishedAt;
        Status = status;
    }

    public static Recipe Create(Guid chefId, string title, string description, string instructions,
        int cookingTime, int servings)
    {
        if (chefId == Guid.Empty)
            throw new ArgumentException("ChefId cannot be empty.", nameof(chefId));
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title cannot be empty.", nameof(title));
        if (cookingTime <= 0)
            throw new ArgumentException("Cooking time must be positive.", nameof(cookingTime));
        if (servings <= 0)
            throw new ArgumentException("Servings must be positive.", nameof(servings));
        var now = DateTime.UtcNow;
        return new Recipe(Guid.NewGuid(), chefId, title, description, instructions,
            cookingTime, servings, now, now, null, RecipeStatus.Draft);
    }

    public static Recipe Restore(Guid id, Guid chefId, string title, string description,
        string instructions, int cookingTime, int servings, DateTime createdAt,
        DateTime updatedAt, DateTime? publishedAt, RecipeStatus status)
        => new Recipe(id, chefId, title, description, instructions,
            cookingTime, servings, createdAt, updatedAt, publishedAt, status);

    public void Update(string title, string description, string instructions)
    {
        if (Status == RecipeStatus.Archived)
            throw new InvalidOperationException("Cannot update archived recipe.");
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title cannot be empty.", nameof(title));
        Title = title;
        Description = description;
        Instructions = instructions;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Publish()
    {
        if (Status == RecipeStatus.Published)
            throw new InvalidOperationException("Recipe is already published.");
        Status = RecipeStatus.Published;
        PublishedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Archive()
    {
        Status = RecipeStatus.Archived;
        UpdatedAt = DateTime.UtcNow;
    }
}