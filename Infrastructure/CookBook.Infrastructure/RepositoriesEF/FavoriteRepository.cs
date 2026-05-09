using CookBook.Domain.Entities;
using CookBook.Domain.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace CookBook.Infrastructure.RepositoriesEF;

public class FavoriteRepository : EFRepository<Favorite>, IFavoriteRepository
{
    public FavoriteRepository(ApplicationDbContext context) : base(context) { }

    public async Task<IReadOnlyList<Favorite>> GetByGourmetIdAsync(Guid gourmetId, CancellationToken cancellationToken = default)
        => await DbSet.Where(f => f.GourmetId == gourmetId).ToListAsync(cancellationToken);

    public async Task<Favorite?> GetByGourmetAndRecipeAsync(Guid gourmetId, Guid recipeId, CancellationToken cancellationToken = default)
        => await DbSet.FirstOrDefaultAsync(f => f.GourmetId == gourmetId && f.RecipeId == recipeId, cancellationToken);

    public async Task<bool> ExistsAsync(Guid gourmetId, Guid recipeId, CancellationToken cancellationToken = default)
        => await DbSet.AnyAsync(f => f.GourmetId == gourmetId && f.RecipeId == recipeId, cancellationToken);
}
