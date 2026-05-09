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
            throw new ArgumentException("RecipeId cannot be empty.", nameof(recipeId));
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be empty.", nameof(name));
        if (name.Length > 100)
            throw new ArgumentException("Name cannot exceed 100 characters.", nameof(name));
        if (quantity.HasValue && quantity.Value < 0)
            throw new ArgumentException("Quantity cannot be negative.", nameof(quantity));
        if (unit != null && unit.Length > 20)
            throw new ArgumentException("Unit cannot exceed 20 characters.", nameof(unit));
        return new Ingredient(Guid.NewGuid(), Guid.NewGuid(), recipeId, name, quantity, unit);
    }

    public static Ingredient Restore(Guid id, Guid uuid, Guid recipeId, string name, decimal? quantity, string? unit)
        => new Ingredient(id, uuid, recipeId, name, quantity, unit);

    public void Update(string name, decimal? quantity = null, string? unit = null)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be empty.", nameof(name));
        Name = name;
        Quantity = quantity;
        Unit = unit;
    }
}
