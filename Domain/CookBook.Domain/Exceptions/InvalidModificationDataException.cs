using CookBook.Domain.Entities;

namespace CookBook.Domain.Exceptions;

public class InvalidModificationDataException(Recipe recipe, DateTime modificationData)
    : ArgumentException($"The recipe time {modificationData} is not correct")
{
    public Recipe Recipe => recipe;
    public DateTime ModificationData => modificationData;
}
