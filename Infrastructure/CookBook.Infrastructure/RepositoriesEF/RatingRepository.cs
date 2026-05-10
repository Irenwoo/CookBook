using CookBook.Domain.Entities;
using CookBook.Domain.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace CookBook.Infrastructure.RepositoriesEF;

public class RatingRepository(ApplicationDbContext context)
    : EFRepository<Rating, Guid>(context), IRatingRepository
{
    private readonly DbSet<Rating> _ratings = context.Set<Rating>();

    public async Task<IEnumerable<Rating>> GetByRecipeIdAsync(Guid recipeId, CancellationToken cancellationToken)
        => await _ratings.Where(r => r.RecipeId == recipeId).ToListAsync(cancellationToken);

    public Task<Rating?> GetByGourmetAndRecipeAsync(Guid gourmetId, Guid recipeId, CancellationToken cancellationToken)
        => _ratings.FirstOrDefaultAsync(r => r.GourmetId == gourmetId && r.RecipeId == recipeId, cancellationToken);

    public async Task<double> GetAverageScoreByRecipeIdAsync(Guid recipeId, CancellationToken cancellationToken)
    {
        var ratings = await _ratings.Where(r => r.RecipeId == recipeId).ToListAsync(cancellationToken);
        return ratings.Count == 0 ? 0 : ratings.Average(r => r.Score);
    }
}