using System;
using CookBook.Domain.Base;

namespace CookBook.Domain
{
    public class Favorite : Entity
    {
        public Guid GourmetId { get; private set; }
        public Guid RecipeId { get; private set; }

        public Favorite(Guid gourmetId, Guid recipeId)
        {
            GourmetId = gourmetId;
            RecipeId = recipeId;
        }
    }
}