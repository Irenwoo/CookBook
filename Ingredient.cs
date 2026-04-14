using System;
using CookBook.Domain.Base;
using CookBook.ValueObjects;

namespace CookBook.Domain
{
    public class Ingredient : Entity
    {
        public Guid RecipeId { get; private set; }
        public IngredientName Name { get; private set; }
        public decimal? Quantity { get; private set; }
        public string? Unit { get; private set; }

        public Ingredient(Guid recipeId, IngredientName name, decimal? quantity = null, string? unit = null)
        {
            RecipeId = recipeId;
            Name = name;
            Quantity = quantity;
            Unit = unit;
        }
    }
}