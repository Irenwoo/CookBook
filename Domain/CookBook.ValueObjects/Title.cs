using CookBook.ValueObjects.Base;
using CookBook.ValueObjects.Validators;

namespace CookBook.ValueObjects;

/// <summary>
/// Represents type of the entity's title.
/// </summary>
/// <param name="title">The title of the entity.</param>
public class Title(string title) : ValueObject<string>(new TitleValidator(), title);