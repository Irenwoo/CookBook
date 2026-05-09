using CookBook.Domain.Base;
using CookBook.ValueObjects;

namespace CookBook.Domain.Entities;

public class Gourmet : BaseEntity
{
    public string Username { get; private set; }
    public DateTime CreatedAt { get; private set; }

    private readonly List<Favorite> _favorites = new();
    public IReadOnlyCollection<Favorite> Favorites => _favorites.AsReadOnly();

    private readonly List<Rating> _ratings = new();
    public IReadOnlyCollection<Rating> Ratings => _ratings.AsReadOnly();

    private readonly List<Comment> _comments = new();
    public IReadOnlyCollection<Comment> Comments => _comments.AsReadOnly();

    private Gourmet() : base() { }

    private Gourmet(Guid id, Guid uuid, string username, DateTime createdAt)
        : base(id, uuid)
    {
        Username = username;
        CreatedAt = createdAt;
    }

    public static Gourmet Create(string username)
    {
        var validatedUsername = new Username(username);
        return new Gourmet(Guid.NewGuid(), Guid.NewGuid(), validatedUsername.Value, DateTime.UtcNow);
    }

    public static Gourmet Restore(Guid id, Guid uuid, string username, DateTime createdAt)
        => new Gourmet(id, uuid, username, createdAt);

    public void UpdateUsername(string username)
    {
        var validatedUsername = new Username(username);
        Username = validatedUsername.Value;
    }
}
