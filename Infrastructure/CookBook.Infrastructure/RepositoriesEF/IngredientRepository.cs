using CookBook.Domain.Entities;
using CookBook.Domain.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace CookBook.Infrastructure.RepositoriesEF;

public class IngredientRepository : EFRepository<Ingredient>, IIngredientRepository
{
    public IngredientRepository(ApplicationDbContext context) : base(context) { }

    public async Task<IReadOnlyList<Ingredient>> GetByRecipeIdAsync(Guid recipeId, CancellationToken cancellationToken = default)
        => await DbSet.Where(i => i.RecipeId == recipeId).ToListAsync(cancellationToken);

    public async Task DeleteByRecipeIdAsync(Guid recipeId, CancellationToken cancellationToken = default)
    {
        var ingredients = await DbSet.Where(i => i.RecipeId == recipeId).ToListAsync(cancellationToken);
        DbSet.RemoveRange(ingredients);
        await Context.SaveChangesAsync(cancellationToken);
    }
}
