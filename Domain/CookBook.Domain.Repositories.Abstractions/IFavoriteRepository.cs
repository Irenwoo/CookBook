using CookBook.Domain.Entities;
using CookBook.Domain.Repositories.Abstractions.Base;

namespace CookBook.Domain.Repositories.Abstractions;

public interface IFavoriteRepository : IRepository<Favorite, Guid>
{
    Task<IEnumerable<Favorite>> GetByGourmetIdAsync(Guid gourmetId, CancellationToken cancellationToken);
    Task<Favorite?> GetByGourmetAndRecipeAsync(Guid gourmetId, Guid recipeId, CancellationToken cancellationToken);
    Task<bool> ExistsAsync(Guid gourmetId, Guid recipeId, CancellationToken cancellationToken);
}