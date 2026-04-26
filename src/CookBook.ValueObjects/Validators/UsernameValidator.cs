namespace CookBook.ValueObjects.Validators;

public static class UsernameValidator
{
    public const int MaxLength = 50;

    public static bool IsValid(string? value, out string errorMessage)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            errorMessage = "Имя пользователя не может быть пустым.";
            return false;
        }

        if (value.Length > MaxLength)
        {
            errorMessage = $"Длина имени пользователя не должна превышать {MaxLength} символов.";
            return false;
        }

        errorMessage = string.Empty;
        return true;
    }
}
