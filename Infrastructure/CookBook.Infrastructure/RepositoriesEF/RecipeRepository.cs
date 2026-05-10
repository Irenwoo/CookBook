using CookBook.Domain.Entities;
using CookBook.Domain.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace CookBook.Infrastructure.RepositoriesEF;

public class RecipeRepository(ApplicationDbContext context)
    : EFRepository<Recipe, Guid>(context), IRecipeRepository
{
    public async Task<IEnumerable<Recipe>> GetByChefIdAsync(Guid chefId, CancellationToken cancellationToken)
        => await context.Set<Recipe>().Where(r => r.ChefId == chefId).ToListAsync(cancellationToken);

    public async Task<IEnumerable<Recipe>> GetPublishedAsync(CancellationToken cancellationToken)
        => await context.Set<Recipe>().Where(r => r.Status == RecipeStatus.Published).ToListAsync(cancellationToken);

    public Task<Recipe?> GetWithDetailsAsync(Guid id, CancellationToken cancellationToken)
        => context.Set<Recipe>()
        .Include(r => r.Ingredients)
        .Include(r => r.Photos)
        .Include(r => r.Comments)
        .Include(r => r.Ratings)
        .FirstOrDefaultAsync(r => r.Id == id, cancellationToken);

    public async Task<IEnumerable<Recipe>> GetByStatusAsync(RecipeStatus status, CancellationToken cancellationToken)
        => await context.Set<Recipe>().Where(r => r.Status == status).ToListAsync(cancellationToken);
}