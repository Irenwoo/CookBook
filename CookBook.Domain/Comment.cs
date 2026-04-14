using System;
using CookBook.Domain.Base;
using CookBook.ValueObjects;

namespace CookBook.Domain
{
    public class Comment : Entity
    {
        public Guid GourmetId { get; private set; }
        public Guid RecipeId { get; private set; }
        public Content Content { get; private set; }
        public DateTime? UpdatedAt { get; private set; }

        public Comment(Guid gourmetId, Guid recipeId, Content content)
        {
            GourmetId = gourmetId;
            RecipeId = recipeId;
            Content = content;
        }

        public void UpdateContent(Content newContent)
        {
            Content = newContent;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}