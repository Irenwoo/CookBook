using CookBook.Domain.Entities;
using CookBook.Domain.Repositories.Abstractions.Base;

namespace CookBook.Domain.Repositories.Abstractions;

public interface IChefRepository : IRepository<Chef, Guid>
{
    Task<Chef?> GetByUsernameAsync(string username, CancellationToken cancellationToken);
    Task<bool> ExistsByUsernameAsync(string username, CancellationToken cancellationToken);
    Task<IEnumerable<Chef>> GetWithRecipesAsync(CancellationToken cancellationToken);
}