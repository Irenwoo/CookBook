using CookBook.ValueObjects.Base;
using CookBook.ValueObjects.Exceptions;

namespace CookBook.ValueObjects.Validators
{
    public class UsernameValidator : IValidator<string>
    {
        public void Validate(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullOrWhiteSpaceException(nameof(Username));

            if (value.Length < 3)
                throw new ArgumentShortValueException(nameof(Username), 3, value.Length);

            if (value.Length > 50)
                throw new ArgumentLongValueException(nameof(Username), 50, value.Length);
        }
    }
}