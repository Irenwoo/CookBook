namespace CookBook.ValueObjects.Exceptions;

/// <summary>
/// Exception thrown when a string argument is null, empty or consists only of white-space characters.
/// </summary>
public class ArgumentNullOrWhiteSpaceException(string paramName)
    : ArgumentNullException(paramName, $"The \"{paramName}\" mustn't be null, empty or consists only of white-space characters.");
