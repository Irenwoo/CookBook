namespace CookBook.ValueObjects.Exceptions;

/// <summary>
/// Exception thrown when a string argument exceeds the maximum length.
/// </summary>
public class ArgumentLongValueException(string paramName, string value, int maxLength)
    : FormatException($"The \"{paramName}\" length {value} greater than maximum allowed length {maxLength}")
{
    public string Value => value;
    public int MaxLength => maxLength;
}
