namespace CookBook.ValueObjects.Exceptions;

public class InvalidTitleException : ValueObjectException
{
    public InvalidTitleException(string message) : base(message) { }
}
