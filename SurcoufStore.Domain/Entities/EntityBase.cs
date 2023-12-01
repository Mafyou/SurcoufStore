namespace SurcoufStore.Domain.Entities;

public abstract class EntityBase(int id)
{
    public int Id { get; set; } = id;
}
