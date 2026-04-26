using CookBook.Domain.Entities;
using CookBook.Domain.Repositories.Abstractions.Base;

namespace CookBook.Domain.Repositories.Abstractions;

public interface IRecipeRepository : IRepository<Recipe>
{
    Task<IReadOnlyList<Recipe>> GetByChefIdAsync(Guid chefId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Recipe>> GetPublishedAsync(CancellationToken cancellationToken = default);
    Task<Recipe?> GetWithDetailsAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Recipe>> GetByStatusAsync(RecipeStatus status, CancellationToken cancellationToken = default);
}
