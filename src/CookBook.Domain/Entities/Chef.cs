using CookBook.Domain.Base;

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
        if (string.IsNullOrWhiteSpace(username))
            throw new ArgumentException("Имя пользователя не может быть пустым.", nameof(username));

        if (username.Length > 50)
            throw new ArgumentException("Длина имени пользователя не должна превышать 50 символов.", nameof(username));

        return new Chef(Guid.NewGuid(), Guid.NewGuid(), username, DateTime.UtcNow);
    }

    public static Chef Restore(Guid id, Guid uuid, string username, DateTime createdAt)
        => new Chef(id, uuid, username, createdAt);

    public void UpdateUsername(string username)
    {
        if (string.IsNullOrWhiteSpace(username))
            throw new ArgumentException("Имя пользователя не может быть пустым.", nameof(username));

        if (username.Length > 50)
            throw new ArgumentException("Длина имени пользователя не должна превышать 50 символов.", nameof(username));

        Username = username;
    }
}
