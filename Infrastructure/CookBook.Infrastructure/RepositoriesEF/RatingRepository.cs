using CookBook.Domain.Entities;
using CookBook.Domain.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace CookBook.Infrastructure.RepositoriesEF;

public class RatingRepository : EFRepository<Rating>, IRatingRepository
{
    public RatingRepository(ApplicationDbContext context) : base(context) { }

    public async Task<IReadOnlyList<Rating>> GetByRecipeIdAsync(Guid recipeId, CancellationToken cancellationToken = default)
        => await DbSet.Where(r => r.RecipeId == recipeId).ToListAsync(cancellationToken);

    public async Task<Rating?> GetByGourmetAndRecipeAsync(Guid gourmetId, Guid recipeId, CancellationToken cancellationToken = default)
        => await DbSet.FirstOrDefaultAsync(r => r.GourmetId == gourmetId && r.RecipeId == recipeId, cancellationToken);

    public async Task<double> GetAverageScoreByRecipeIdAsync(Guid recipeId, CancellationToken cancellationToken = default)
    {
        var ratings = await DbSet.Where(r => r.RecipeId == recipeId).ToListAsync(cancellationToken);
        return ratings.Count == 0 ? 0 : ratings.Average(r => r.Score);
    }
}
