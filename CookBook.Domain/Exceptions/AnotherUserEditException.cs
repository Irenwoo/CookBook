using System;

namespace CookBook.Domain.Exceptions
{
    public class AnotherUserEditException : DomainException
    {
        public AnotherUserEditException(Guid entityId, Guid currentUserId, Guid ownerId)
            : base($"Cannot edit {entityId}. User {currentUserId} is not the owner. Owner is {ownerId}")
        {
        }
    }
}