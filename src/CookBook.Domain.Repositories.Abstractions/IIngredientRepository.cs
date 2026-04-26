using CookBook.Domain.Entities;
using CookBook.Domain.Repositories.Abstractions.Base;

namespace CookBook.Domain.Repositories.Abstractions;

public interface IIngredientRepository : IRepository<Ingredient>
{
    Task<IReadOnlyList<Ingredient>> GetByRecipeIdAsync(Guid recipeId, CancellationToken cancellationToken = default);
    Task DeleteByRecipeIdAsync(Guid recipeId, CancellationToken cancellationToken = default);
}
