using CookBook.Domain.Entities;
using CookBook.Domain.Repositories.Abstractions.Base;

namespace CookBook.Domain.Repositories.Abstractions;

public interface IGourmetRepository : IRepository<Gourmet, Guid>
{
    Task<Gourmet?> GetByUsernameAsync(string username, CancellationToken cancellationToken);
    Task<bool> ExistsByUsernameAsync(string username, CancellationToken cancellationToken);
    Task<Gourmet?> GetWithFavoritesAsync(Guid id, CancellationToken cancellationToken);
}