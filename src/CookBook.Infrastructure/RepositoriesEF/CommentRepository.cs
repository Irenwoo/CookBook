using CookBook.Domain.Entities;
using CookBook.Domain.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace CookBook.Infrastructure.RepositoriesEF;

public class CommentRepository : EFRepository<Comment>, ICommentRepository
{
    public CommentRepository(ApplicationDbContext context) : base(context) { }

    public async Task<IReadOnlyList<Comment>> GetByRecipeIdAsync(Guid recipeId, CancellationToken cancellationToken = default)
        => await DbSet.Where(c => c.RecipeId == recipeId).ToListAsync(cancellationToken);

    public async Task<IReadOnlyList<Comment>> GetByGourmetIdAsync(Guid gourmetId, CancellationToken cancellationToken = default)
        => await DbSet.Where(c => c.GourmetId == gourmetId).ToListAsync(cancellationToken);
}
