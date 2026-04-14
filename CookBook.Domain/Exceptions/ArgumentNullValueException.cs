namespace CookBook.Domain.Exceptions
{
    public class ArgumentNullValueException : DomainException
    {
        public ArgumentNullValueException(string paramName)
            : base($"{paramName} cannot be null")
        {
        }
    }
}