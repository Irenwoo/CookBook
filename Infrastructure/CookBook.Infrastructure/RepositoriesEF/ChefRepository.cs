using CookBook.Domain.Entities;
using CookBook.Domain.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace CookBook.Infrastructure.RepositoriesEF;

public class ChefRepository : EFRepository<Chef>, IChefRepository
{
    public ChefRepository(ApplicationDbContext context) : base(context) { }

    public async Task<Chef?> GetByUsernameAsync(string username, CancellationToken cancellationToken = default)
        => await DbSet.FirstOrDefaultAsync(c => c.Username == username, cancellationToken);

    public async Task<bool> ExistsByUsernameAsync(string username, CancellationToken cancellationToken = default)
        => await DbSet.AnyAsync(c => c.Username == username, cancellationToken);

    public async Task<IReadOnlyList<Chef>> GetWithRecipesAsync(CancellationToken cancellationToken = default)
        => await DbSet.Include(c => c.Recipes).ToListAsync(cancellationToken);
}
