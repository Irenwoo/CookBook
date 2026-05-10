using CookBook.Domain.Entities;
using CookBook.Domain.Repositories.Abstractions.Base;

namespace CookBook.Domain.Repositories.Abstractions;

public interface IIngredientRepository : IRepository<Ingredient, Guid>
{
    Task<IEnumerable<Ingredient>> GetByRecipeIdAsync(Guid recipeId, CancellationToken cancellationToken);
    Task DeleteByRecipeIdAsync(Guid recipeId, CancellationToken cancellationToken);
}