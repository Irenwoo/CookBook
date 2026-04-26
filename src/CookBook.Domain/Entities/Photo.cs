using CookBook.Domain.Base;

namespace CookBook.Domain.Entities;

public class Photo : BaseEntity
{
    public Guid RecipeId { get; private set; }
    public string Url { get; private set; }
    public bool IsMain { get; private set; }

    public Recipe? Recipe { get; private set; }

    private Photo() : base() { }

    private Photo(Guid id, Guid uuid, Guid recipeId, string url, bool isMain)
        : base(id, uuid)
    {
        RecipeId = recipeId;
        Url = url;
        IsMain = isMain;
    }

    public static Photo Create(Guid recipeId, string url, bool isMain = false)
    {
        if (recipeId == Guid.Empty)
            throw new ArgumentException("Идентификатор рецепта не может быть пустым.", nameof(recipeId));

        if (string.IsNullOrWhiteSpace(url))
            throw new ArgumentException("", nameof(url));

        if (url.Length > 255)
            throw new ArgumentException("Url-адрес не может быть пустым.", nameof(url));

        return new Photo(Guid.NewGuid(), Guid.NewGuid(), recipeId, url, isMain);
    }

    public static Photo Restore(Guid id, Guid uuid, Guid recipeId, string url, bool isMain)
        => new Photo(id, uuid, recipeId, url, isMain);

    public void SetAsMain() => IsMain = true;
    public void UnsetAsMain() => IsMain = false;
}
