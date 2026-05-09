using CookBook.Domain.Entities;
using CookBook.Domain.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace CookBook.Infrastructure.RepositoriesEF;

public class RecipeRepository : EFRepository<Recipe>, IRecipeRepository
{
    public RecipeRepository(ApplicationDbContext context) : base(context) { }

    public async Task<IReadOnlyList<Recipe>> GetByChefIdAsync(Guid chefId, CancellationToken cancellationToken = default)
        => await DbSet.Where(r => r.ChefId == chefId).ToListAsync(cancellationToken);

    public async Task<IReadOnlyList<Recipe>> GetPublishedAsync(CancellationToken cancellationToken = default)
        => await DbSet.Where(r => r.Status == RecipeStatus.Published).ToListAsync(cancellationToken);

    public async Task<Recipe?> GetWithDetailsAsync(Guid id, CancellationToken cancellationToken = default)
        => await DbSet
            .Include(r => r.Ingredients)
            .Include(r => r.Photos)
            .Include(r => r.Comments)
            .Include(r => r.Ratings)
            .FirstOrDefaultAsync(r => r.Id == id, cancellationToken);

    public async Task<IReadOnlyList<Recipe>> GetByStatusAsync(RecipeStatus status, CancellationToken cancellationToken = default)
        => await DbSet.Where(r => r.Status == status).ToListAsync(cancellationToken);
}
