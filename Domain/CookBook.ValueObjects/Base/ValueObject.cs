 using CookBook.ValueObjects.Exceptions;

namespace CookBook.ValueObjects.Base;

/// <summary>
/// Base class for all value objects.
/// </summary>
/// <typeparam name="T">The type of the value.</typeparam>
public abstract class ValueObject<T> : IEquatable<ValueObject<T>>
{
    public T Value { get; }

    protected ValueObject(IValidator<T> validator, T value)
    {
        if (validator == null)
            throw new ValidatorNullException(nameof(validator));

        validator.Validate(value);
        Value = value;
    }

    public override string ToString()
        => Value!.ToString() ?? GetType().ToString();

    public override int GetHashCode()
        => Value!.GetHashCode();

    public override bool Equals(object? other)
        => Equals(other as ValueObject<T>);

    public bool Equals(ValueObject<T>? other)
    {
        if (other is null)
            return false;
        if (ReferenceEquals(this, other))
            return true;
        if (GetType() != other.GetType())
            return false;
        return other.Value!.Equals(Value);
    }

    public static bool operator ==(ValueObject<T>? left, ValueObject<T>? right)
        => Equals(left, right);

    public static bool operator !=(ValueObject<T>? left, ValueObject<T>? right)
        => !(left == right);
}
