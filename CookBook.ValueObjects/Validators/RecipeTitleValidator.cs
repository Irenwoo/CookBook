using CookBook.ValueObjects.Base;
using CookBook.ValueObjects.Exceptions;

namespace CookBook.ValueObjects.Validators
{
    public class RecipeTitleValidator : IValidator<string>
    {
        public void Validate(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullOrWhiteSpaceException(nameof(RecipeTitle));

            if (value.Length < 3)
                throw new ArgumentShortValueException(nameof(RecipeTitle), 3, value.Length);

            if (value.Length > 100)
                throw new ArgumentLongValueException(nameof(RecipeTitle), 100, value.Length);
        }
    }
}