using System;

namespace CookBook.ValueObjects.Exceptions
{
    public class ArgumentNullOrWhiteSpaceException : Exception
    {
        public ArgumentNullOrWhiteSpaceException(string paramName)
            : base($"{paramName} cannot be null or whitespace.")
        {
        }
    }
}