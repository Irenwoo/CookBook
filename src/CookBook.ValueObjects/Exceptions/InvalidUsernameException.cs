namespace CookBook.ValueObjects.Exceptions;

public class InvalidUsernameException : ValueObjectException
{
    public InvalidUsernameException(string message) : base(message) { }
}
