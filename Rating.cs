using System;
using CookBook.Domain.Base;
using CookBook.Domain.Exceptions;

namespace CookBook.Domain
{
    public class Rating : Entity
    {
        public Guid GourmetId { get; private set; }
        public Guid RecipeId { get; private set; }
        public int Score { get; private set; }
        public DateTime? UpdatedAt { get; private set; }

        public Rating(Guid gourmetId, Guid recipeId, int score)
        {
            GourmetId = gourmetId;
            RecipeId = recipeId;
            SetScore(score);
        }

        public void UpdateScore(int newScore)
        {
            SetScore(newScore);
            UpdatedAt = DateTime.UtcNow;
        }

        private void SetScore(int score)
        {
            if (score < 1 || score > 5)
                throw new InvalidModificationDataException("Score must be between 1 and 5");

            Score = score;
        }
    }
}