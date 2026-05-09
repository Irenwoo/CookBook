using CookBook.Domain.Entities;
using CookBook.Domain.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace CookBook.Infrastructure.RepositoriesEF;

public class PhotoRepository : EFRepository<Photo>, IPhotoRepository
{
    public PhotoRepository(ApplicationDbContext context) : base(context) { }

    public async Task<IReadOnlyList<Photo>> GetByRecipeIdAsync(Guid recipeId, CancellationToken cancellationToken = default)
        => await DbSet.Where(p => p.RecipeId == recipeId).ToListAsync(cancellationToken);

    public async Task<Photo?> GetMainPhotoByRecipeIdAsync(Guid recipeId, CancellationToken cancellationToken = default)
        => await DbSet.FirstOrDefaultAsync(p => p.RecipeId == recipeId && p.IsMain, cancellationToken);
}
