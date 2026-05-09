using CookBook.Domain.Entities;
using CookBook.Domain.Repositories.Abstractions.Base;

namespace CookBook.Domain.Repositories.Abstractions;

public interface ICommentRepository : IRepository<Comment>
{
    Task<IReadOnlyList<Comment>> GetByRecipeIdAsync(Guid recipeId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Comment>> GetByGourmetIdAsync(Guid gourmetId, CancellationToken cancellationToken = default);
}
