namespace CookBook.ValueObjects.Base;

/// <summary>
/// Defines a method that implements the validation of the value.
/// </summary>
/// <typeparam name="T">The type of the value to validate.</typeparam>
public interface IValidator<T>
{
    /// <summary>
    /// Validates the value.
    /// </summary>
    /// <param name="value">The value to validate.</param>
    void Validate(T value);
}
