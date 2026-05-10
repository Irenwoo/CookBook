using CookBook.Domain.Entities;
using CookBook.Domain.Repositories.Abstractions;
using CookBook.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace CookBook.Infrastructure.RepositoriesEF;

public class ChefRepository(ApplicationDbContext context)
    : EFRepository<Chef, Guid>(context), IChefRepository
{
    private readonly DbSet<Chef> _chefs = context.Set<Chef>();

    public override Task<Chef?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        => _chefs.Include(c => c.Recipes)
        .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

    public Task<Chef?> GetByUsernameAsync(string username, CancellationToken cancellationToken)
        => _chefs.FirstOrDefaultAsync(c => c.Username == username, cancellationToken);

    public Task<bool> ExistsByUsernameAsync(string username, CancellationToken cancellationToken)
        => _chefs.AnyAsync(c => c.Username == username, cancellationToken);

    public async Task<IEnumerable<Chef>> GetWithRecipesAsync(CancellationToken cancellationToken)
        => await _chefs.Include(c => c.Recipes).ToListAsync(cancellationToken);
}