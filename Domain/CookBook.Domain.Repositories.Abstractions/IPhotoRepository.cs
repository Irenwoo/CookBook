using CookBook.Domain.Entities;
using CookBook.Domain.Repositories.Abstractions.Base;

namespace CookBook.Domain.Repositories.Abstractions;

public interface IPhotoRepository : IRepository<Photo, Guid>
{
    Task<IEnumerable<Photo>> GetByRecipeIdAsync(Guid recipeId, CancellationToken cancellationToken);
    Task<Photo?> GetMainPhotoByRecipeIdAsync(Guid recipeId, CancellationToken cancellationToken);
}