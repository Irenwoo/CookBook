using System;

namespace CookBook.ValueObjects.Exceptions
{
    public class ArgumentLongValueException : Exception
    {
        public ArgumentLongValueException(string paramName, int maxLength, int actualLength)
            : base($"{paramName} length {actualLength} exceeds maximum {maxLength}.")
        {
        }
    }
}