using CookBook.Domain.Entities;
using CookBook.Domain.Repositories.Abstractions.Base;

namespace CookBook.Domain.Repositories.Abstractions;

public interface IChefRepository : IRepository<Chef>
{
    Task<Chef?> GetByUsernameAsync(string username, CancellationToken cancellationToken = default);
    Task<bool> ExistsByUsernameAsync(string username, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Chef>> GetWithRecipesAsync(CancellationToken cancellationToken = default);
}
