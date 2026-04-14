using System;

namespace CookBook.ValueObjects.Exceptions
{
    public class ValidatorNullException : Exception
    {
        public ValidatorNullException()
            : base("Validator cannot be null.")
        {
        }
    }
}