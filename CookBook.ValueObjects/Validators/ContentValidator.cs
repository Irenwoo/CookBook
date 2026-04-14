using CookBook.ValueObjects.Base;
using CookBook.ValueObjects.Exceptions;

namespace CookBook.ValueObjects.Validators
{
    public class ContentValidator : IValidator<string>
    {
        public void Validate(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullOrWhiteSpaceException(nameof(Content));

            if (value.Length < 1)
                throw new ArgumentShortValueException(nameof(Content), 1, value.Length);

            if (value.Length > 1000)
                throw new ArgumentLongValueException(nameof(Content), 1000, value.Length);
        }
    }
}