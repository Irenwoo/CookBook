using System;

namespace CookBook.Domain.Exceptions
{
    public class InvalidModificationDataException : DomainException
    {
        public InvalidModificationDataException(string message) : base(message)
        {
        }
    }
}