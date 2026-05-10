using CookBook.Domain.Entities;
using CookBook.Domain.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace CookBook.Infrastructure.RepositoriesEF;

public class FavoriteRepository(ApplicationDbContext context)
    : EFRepository<Favorite, Guid>(context), IFavoriteRepository
{
    private readonly DbSet<Favorite> _favorites = context.Set<Favorite>();

    public async Task<IEnumerable<Favorite>> GetByGourmetIdAsync(Guid gourmetId, CancellationToken cancellationToken)
        => await _favorites.Where(f => f.GourmetId == gourmetId).ToListAsync(cancellationToken);

    public Task<Favorite?> GetByGourmetAndRecipeAsync(Guid gourmetId, Guid recipeId, CancellationToken cancellationToken)
        => _favorites.FirstOrDefaultAsync(f => f.GourmetId == gourmetId && f.RecipeId == recipeId, cancellationToken);

    public Task<bool> ExistsAsync(Guid gourmetId, Guid recipeId, CancellationToken cancellationToken)
        => _favorites.AnyAsync(f => f.GourmetId == gourmetId && f.RecipeId == recipeId, cancellationToken);
}