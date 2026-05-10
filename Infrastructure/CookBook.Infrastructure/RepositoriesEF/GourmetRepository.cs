using CookBook.Domain.Entities;
using CookBook.Domain.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace CookBook.Infrastructure.RepositoriesEF;

public class GourmetRepository(ApplicationDbContext context)
    : EFRepository<Gourmet, Guid>(context), IGourmetRepository
{
    private readonly DbSet<Gourmet> _gourmets = context.Set<Gourmet>();

    public Task<Gourmet?> GetByUsernameAsync(string username, CancellationToken cancellationToken)
        => _gourmets.FirstOrDefaultAsync(g => g.Username == username, cancellationToken);

    public Task<bool> ExistsByUsernameAsync(string username, CancellationToken cancellationToken)
        => _gourmets.AnyAsync(g => g.Username == username, cancellationToken);

    public Task<Gourmet?> GetWithFavoritesAsync(Guid id, CancellationToken cancellationToken)
        => _gourmets.Include(g => g.Favorites)
        .FirstOrDefaultAsync(g => g.Id == id, cancellationToken);
}