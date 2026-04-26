using CookBook.Domain.Base;

namespace CookBook.Domain.Entities;

public class Ingredient : BaseEntity
{
    public Guid RecipeId { get; private set; }
    public string Name { get; private set; }
    public decimal? Quantity { get; private set; }
    public string? Unit { get; private set; }

    public Recipe? Recipe { get; private set; }

    private Ingredient() : base() { }

    private Ingredient(Guid id, Guid uuid, Guid recipeId, string name, decimal? quantity, string? unit)
        : base(id, uuid)
    {
        RecipeId = recipeId;
        Name = name;
        Quantity = quantity;
        Unit = unit;
    }

    public static Ingredient Create(Guid recipeId, string name, decimal? quantity = null, string? unit = null)
    {
        if (recipeId == Guid.Empty)
            throw new ArgumentException("Идентификатор рецепта не может быть пустым.", nameof(recipeId));

        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Имя не может быть пустым.", nameof(name));

        if (name.Length > 100)
            throw new ArgumentException("Длина имени не должна превышать 100 символов.", nameof(name));

        if (quantity.HasValue && quantity.Value < 0)
            throw new ArgumentException("Количество не может быть отрицательным.", nameof(quantity));

        if (unit != null && unit.Length > 20)
            throw new ArgumentException("Объем текста не должен превышать 20 символов.", nameof(unit));

        return new Ingredient(Guid.NewGuid(), Guid.NewGuid(), recipeId, name, quantity, unit);
    }

    public static Ingredient Restore(Guid id, Guid uuid, Guid recipeId, string name, decimal? quantity, string? unit)
        => new Ingredient(id, uuid, recipeId, name, quantity, unit);

    public void Update(string name, decimal? quantity = null, string? unit = null)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Имя не может быть пустым.", nameof(name));

        Name = name;
        Quantity = quantity;
        Unit = unit;
    }
}
