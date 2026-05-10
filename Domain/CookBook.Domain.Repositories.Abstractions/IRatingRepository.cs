using CookBook.Domain.Entities;
using CookBook.Domain.Repositories.Abstractions.Base;

namespace CookBook.Domain.Repositories.Abstractions;

public interface IRatingRepository : IRepository<Rating, Guid>
{
    Task<IEnumerable<Rating>> GetByRecipeIdAsync(Guid recipeId, CancellationToken cancellationToken);
    Task<Rating?> GetByGourmetAndRecipeAsync(Guid gourmetId, Guid recipeId, CancellationToken cancellationToken);
    Task<double> GetAverageScoreByRecipeIdAsync(Guid recipeId, CancellationToken cancellationToken);
}