namespace CookBook.Domain.Exceptions
{
    public class RecipeNotBelongUserException : DomainException
    {
        public RecipeNotBelongUserException(Guid recipeId, Guid userId)
            : base($"Recipe {recipeId} does not belong to user {userId}")
        {
        }
    }
}