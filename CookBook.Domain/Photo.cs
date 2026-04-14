using System;
using CookBook.Domain.Base;

namespace CookBook.Domain
{
    public class Photo : Entity
    {
        public Guid RecipeId { get; private set; }
        public string Url { get; private set; }
        public bool IsMain { get; private set; }

        public Photo(Guid recipeId, string url, bool isMain = false)
        {
            RecipeId = recipeId;
            Url = url;
            IsMain = isMain;
        }

        public void SetAsMain()
        {
            IsMain = true;
        }

        public void UnsetAsMain()
        {
            IsMain = false;
        }
    }
}