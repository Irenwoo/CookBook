using CookBook.Domain.Entities;
using CookBook.Domain.Repositories.Abstractions.Base;

namespace CookBook.Domain.Repositories.Abstractions;

public interface IGourmetRepository : IRepository<Gourmet>
{
    Task<Gourmet?> GetByUsernameAsync(string username, CancellationToken cancellationToken = default);
    Task<bool> ExistsByUsernameAsync(string username, CancellationToken cancellationToken = default);
    Task<Gourmet?> GetWithFavoritesAsync(Guid id, CancellationToken cancellationToken = default);
}
