namespace CookBook.ValueObjects.Exceptions;

/// <summary>
/// Exception thrown when a string argument is shorter than the minimum length.
/// </summary>
public class ArgumentShortValueException(string paramName, string value, int minLength)
    : FormatException($"The \"{paramName}\" length {value} less than minimum allowed length {minLength}")
{
    public string Value => value;
    public int MinLength => minLength;
}
