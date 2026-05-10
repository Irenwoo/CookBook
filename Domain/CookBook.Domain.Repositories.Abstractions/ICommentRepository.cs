using CookBook.Domain.Entities;
using CookBook.Domain.Repositories.Abstractions.Base;

namespace CookBook.Domain.Repositories.Abstractions;

public interface ICommentRepository : IRepository<Comment, Guid>
{
    Task<IEnumerable<Comment>> GetByRecipeIdAsync(Guid recipeId, CancellationToken cancellationToken);
    Task<IEnumerable<Comment>> GetByGourmetIdAsync(Guid gourmetId, CancellationToken cancellationToken);
}