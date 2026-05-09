using CookBook.Domain.Entities;

namespace CookBook.Domain.Exceptions;

public class RecipeNotBelongChefException(Recipe recipe, Chef chef)
    : InvalidOperationException($"The recipe {recipe.Title} is not in the chef's recipe sequence (chef {chef.Username}, recipe id = {recipe.Id}).")
{
    public Recipe Recipe => recipe;
    public Chef Chef => chef;
}
