namespace CookBook.ValueObjects.Exceptions;

public abstract class ValueObjectException : Exception
{
    protected ValueObjectException(string message) : base(message) { }
}
