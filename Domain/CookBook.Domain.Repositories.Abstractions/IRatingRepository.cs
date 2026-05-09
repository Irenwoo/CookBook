using CookBook.Domain.Entities;
using CookBook.Domain.Repositories.Abstractions.Base;

namespace CookBook.Domain.Repositories.Abstractions;

public interface IRatingRepository : IRepository<Rating>
{
    Task<IReadOnlyList<Rating>> GetByRecipeIdAsync(Guid recipeId, CancellationToken cancellationToken = default);
    Task<Rating?> GetByGourmetAndRecipeAsync(Guid gourmetId, Guid recipeId, CancellationToken cancellationToken = default);
    Task<double> GetAverageScoreByRecipeIdAsync(Guid recipeId, CancellationToken cancellationToken = default);
}
