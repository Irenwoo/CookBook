using CookBook.ValueObjects.Base;
using CookBook.ValueObjects.Exceptions;

namespace CookBook.ValueObjects.Validators
{
    public class IngredientNameValidator : IValidator<string>
    {
        public void Validate(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullOrWhiteSpaceException(nameof(IngredientName));

            if (value.Length < 2)
                throw new ArgumentShortValueException(nameof(IngredientName), 2, value.Length);

            if (value.Length > 100)
                throw new ArgumentLongValueException(nameof(IngredientName), 100, value.Length);
        }
    }
}