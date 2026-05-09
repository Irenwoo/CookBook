namespace CookBook.ValueObjects.Exceptions;

/// <summary>
/// Exception thrown when a validator is null.
/// </summary>
public class ValidatorNullException(string paramName)
    : ArgumentNullException(paramName, $"Validator \"{paramName}\" must be specified for type.");
