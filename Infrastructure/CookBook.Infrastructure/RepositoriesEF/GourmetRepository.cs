using CookBook.Domain.Entities;
using CookBook.Domain.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace CookBook.Infrastructure.RepositoriesEF;

public class GourmetRepository : EFRepository<Gourmet>, IGourmetRepository
{
    public GourmetRepository(ApplicationDbContext context) : base(context) { }

    public async Task<Gourmet?> GetByUsernameAsync(string username, CancellationToken cancellationToken = default)
        => await DbSet.FirstOrDefaultAsync(g => g.Username == username, cancellationToken);

    public async Task<bool> ExistsByUsernameAsync(string username, CancellationToken cancellationToken = default)
        => await DbSet.AnyAsync(g => g.Username == username, cancellationToken);

    public async Task<Gourmet?> GetWithFavoritesAsync(Guid id, CancellationToken cancellationToken = default)
        => await DbSet.Include(g => g.Favorites).FirstOrDefaultAsync(g => g.Id == id, cancellationToken);
}
