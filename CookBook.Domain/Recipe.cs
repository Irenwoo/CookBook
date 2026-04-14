using System;
using CookBook.Domain.Base;
using CookBook.Domain.Enums;
using CookBook.ValueObjects;

namespace CookBook.Domain
{
    public class Recipe : Entity
    {
        public Guid ChefId { get; private set; }
        public RecipeTitle Title { get; private set; }
        public string Description { get; private set; }
        public int? CookingTime { get; private set; }
        public int? Servings { get; private set; }
        public string Instructions { get; private set; }
        public RecipeStatus Status { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public DateTime? PublishedAt { get; private set; }

        public Recipe(Guid chefId, RecipeTitle title, string instructions)
        {
            ChefId = chefId;
            Title = title;
            Instructions = instructions;
            Status = RecipeStatus.Draft;
        }

        public void Publish()
        {
            if (Status == RecipeStatus.Draft)
            {
                Status = RecipeStatus.Published;
                PublishedAt = DateTime.UtcNow;
                UpdateTimestamp();
            }
        }

        public void Archive()
        {
            if (Status != RecipeStatus.Archived)
            {
                Status = RecipeStatus.Archived;
                UpdateTimestamp();
            }
        }

        private void UpdateTimestamp()
        {
            UpdatedAt = DateTime.UtcNow;
        }
    }
}