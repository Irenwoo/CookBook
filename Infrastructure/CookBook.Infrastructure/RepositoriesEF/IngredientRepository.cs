using CookBook.Domain.Entities;
using CookBook.Domain.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace CookBook.Infrastructure.RepositoriesEF;

public class IngredientRepository(ApplicationDbContext context)
    : EFRepository<Ingredient, Guid>(context), IIngredientRepository
{
    public async Task<IEnumerable<Ingredient>> GetByRecipeIdAsync(Guid recipeId, CancellationToken cancellationToken)
        => await context.Set<Ingredient>().Where(i => i.RecipeId == recipeId).ToListAsync(cancellationToken);

    public async Task DeleteByRecipeIdAsync(Guid recipeId, CancellationToken cancellationToken)
    {
        var ingredients = await context.Set<Ingredient>().Where(i => i.RecipeId == recipeId).ToListAsync(cancellationToken);
        context.Set<Ingredient>().RemoveRange(ingredients);
        await context.SaveChangesAsync(cancellationToken);
    }
}