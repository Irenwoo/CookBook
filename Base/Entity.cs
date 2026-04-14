using System;

namespace CookBook.Domain.Base
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; }
        public Guid Uuid { get; protected set; }
        public DateTime CreatedAt { get; protected set; }

        protected Entity()
        {
            Id = Guid.NewGuid();
            Uuid = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
        }
    }
}