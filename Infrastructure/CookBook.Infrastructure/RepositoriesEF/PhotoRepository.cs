using CookBook.Domain.Entities;
using CookBook.Domain.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace CookBook.Infrastructure.RepositoriesEF;

public class PhotoRepository(ApplicationDbContext context)
    : EFRepository<Photo, Guid>(context), IPhotoRepository
{
    private readonly DbSet<Photo> _photos = context.Set<Photo>();

    public async Task<IEnumerable<Photo>> GetByRecipeIdAsync(Guid recipeId, CancellationToken cancellationToken)
        => await _photos.Where(p => p.RecipeId == recipeId).ToListAsync(cancellationToken);

    public Task<Photo?> GetMainPhotoByRecipeIdAsync(Guid recipeId, CancellationToken cancellationToken)
        => _photos.FirstOrDefaultAsync(p => p.RecipeId == recipeId && p.IsMain, cancellationToken);
}