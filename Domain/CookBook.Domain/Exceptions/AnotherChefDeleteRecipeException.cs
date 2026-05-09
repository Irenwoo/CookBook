using CookBook.Domain.Entities;

namespace CookBook.Domain.Exceptions;

public class AnotherChefDeleteRecipeException(Recipe recipe, Chef chef)
    : InvalidOperationException($"The chef {chef.Username} can't delete the {recipe.Title} recipe owned by the chef with id {recipe.ChefId} (recipe id = {recipe.Id}).")
{
    public Recipe Recipe => recipe;
    public Chef Chef => chef;
}
