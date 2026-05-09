using CookBook.Domain.Base;
using CookBook.ValueObjects;

namespace CookBook.Domain.Entities;

public class Chef : BaseEntity
{
    public string Username { get; private set; }
    public DateTime CreatedAt { get; private set; }

    private readonly List<Recipe> _recipes = new();
    public IReadOnlyCollection<Recipe> Recipes => _recipes.AsReadOnly();

    private Chef() : base() { }

    private Chef(Guid id, Guid uuid, string username, DateTime createdAt)
        : base(id, uuid)
    {
        Username = username;
        CreatedAt = createdAt;
    }

    public static Chef Create(string username)
    {
        var validatedUsername = new Username(username);
        return new Chef(Guid.NewGuid(), Guid.NewGuid(), validatedUsername.Value, DateTime.UtcNow);
    }

    public static Chef Restore(Guid id, Guid uuid, string username, DateTime createdAt)
        => new Chef(id, uuid, username, createdAt);

    public void UpdateUsername(string username)
    {
        var validatedUsername = new Username(username);
        Username = validatedUsername.Value;
    }
}