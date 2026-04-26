using CookBook.Domain.Entities;
using CookBook.Domain.Repositories.Abstractions.Base;

namespace CookBook.Domain.Repositories.Abstractions;

public interface IFavoriteRepository : IRepository<Favorite>
{
    Task<IReadOnlyList<Favorite>> GetByGourmetIdAsync(Guid gourmetId, CancellationToken cancellationToken = default);
    Task<Favorite?> GetByGourmetAndRecipeAsync(Guid gourmetId, Guid recipeId, CancellationToken cancellationToken = default);
    Task<bool> ExistsAsync(Guid gourmetId, Guid recipeId, CancellationToken cancellationToken = default);
}
