namespace CookBook.Domain.Base;

public abstract class BaseEntity
{
    public Guid Id { get; protected set; }
    public Guid Uuid { get; protected set; }

    protected BaseEntity()
    {
        Id = Guid.NewGuid();
        Uuid = Guid.NewGuid();
    }

    protected BaseEntity(Guid id, Guid uuid)
    {
        Id = id;
        Uuid = uuid;
    }
}
