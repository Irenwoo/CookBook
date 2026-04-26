using CookBook.ValueObjects.Base;
using CookBook.ValueObjects.Exceptions;
using CookBook.ValueObjects.Validators;

namespace CookBook.ValueObjects;

public sealed class Title : ValueObject
{
    public string Value { get; }

    private Title(string value)
    {
        Value = value;
    }

    public static Title Create(string value)
    {
        if (!TitleValidator.IsValid(value, out var errorMessage))
            throw new InvalidTitleException(errorMessage);

        return new Title(value.Trim());
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString() => Value;

    public static implicit operator string(Title title) => title.Value;
}
