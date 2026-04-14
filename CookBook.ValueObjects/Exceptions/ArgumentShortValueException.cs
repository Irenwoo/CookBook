using System;

namespace CookBook.ValueObjects.Exceptions
{
    public class ArgumentShortValueException : Exception
    {
        public ArgumentShortValueException(string paramName, int minLength, int actualLength)
            : base($"{paramName} length {actualLength} is less than minimum {minLength}.")
        {
        }
    }
}