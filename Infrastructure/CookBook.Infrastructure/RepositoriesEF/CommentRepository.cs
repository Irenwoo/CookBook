using CookBook.Domain.Entities;
using CookBook.Domain.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace CookBook.Infrastructure.RepositoriesEF;

public class CommentRepository(ApplicationDbContext context)
    : EFRepository<Comment, Guid>(context), ICommentRepository
{
    private readonly DbSet<Comment> _comments = context.Set<Comment>();

    public async Task<IEnumerable<Comment>> GetByRecipeIdAsync(Guid recipeId, CancellationToken cancellationToken)
        => await _comments.Where(c => c.RecipeId == recipeId).ToListAsync(cancellationToken);

    public async Task<IEnumerable<Comment>> GetByGourmetIdAsync(Guid gourmetId, CancellationToken cancellationToken)
        => await _comments.Where(c => c.GourmetId == gourmetId).ToListAsync(cancellationToken);
}