using CookBook.Domain.Entities;
using CookBook.Domain.Repositories.Abstractions.Base;

namespace CookBook.Domain.Repositories.Abstractions;

public interface IRecipeRepository : IRepository<Recipe, Guid>
{
    Task<IEnumerable<Recipe>> GetByChefIdAsync(Guid chefId, CancellationToken cancellationToken);
    Task<IEnumerable<Recipe>> GetPublishedAsync(CancellationToken cancellationToken);
    Task<Recipe?> GetWithDetailsAsync(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<Recipe>> GetByStatusAsync(RecipeStatus status, CancellationToken cancellationToken);
}