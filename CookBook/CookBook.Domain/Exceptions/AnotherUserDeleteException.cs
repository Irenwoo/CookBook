using System;

namespace CookBook.Domain.Exceptions
{
    public class AnotherUserDeleteException : DomainException
    {
        public AnotherUserDeleteException(Guid entityId, Guid currentUserId, Guid ownerId)
            : base($"Cannot delete {entityId}. User {currentUserId} is not the owner. Owner is {ownerId}")
        {
        }
    }
}