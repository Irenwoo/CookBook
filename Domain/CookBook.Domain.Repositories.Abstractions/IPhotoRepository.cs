using CookBook.Domain.Entities;
using CookBook.Domain.Repositories.Abstractions.Base;

namespace CookBook.Domain.Repositories.Abstractions;

public interface IPhotoRepository : IRepository<Photo>
{
    Task<IReadOnlyList<Photo>> GetByRecipeIdAsync(Guid recipeId, CancellationToken cancellationToken = default);
    Task<Photo?> GetMainPhotoByRecipeIdAsync(Guid recipeId, CancellationToken cancellationToken = default);
}
