using CookBook.ValueObjects.Base;
using CookBook.ValueObjects.Exceptions;
using CookBook.ValueObjects.Validators;

namespace CookBook.ValueObjects;

public sealed class Username : ValueObject
{
    public string Value { get; }

    private Username(string value)
    {
        Value = value;
    }

    public static Username Create(string value)
    {
        if (!UsernameValidator.IsValid(value, out var errorMessage))
            throw new InvalidUsernameException(errorMessage);

        return new Username(value.Trim());
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString() => Value;

    public static implicit operator string(Username username) => username.Value;
}
