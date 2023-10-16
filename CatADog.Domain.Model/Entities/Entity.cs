using System;

namespace CatADog.Domain.Model.Entities;

public abstract class Entity : IEquatable<Entity>, IEntity
{
    public virtual long Id { get; set; }

    public virtual bool Equals(Entity? other)
    {
        if (other == null) return false;

        // if the value is the default for both
        // then compare references
        if (other.Id.Equals(default) && Id.Equals(default))
            return ReferenceEquals(this, other);

        // verify if they have the same type and value
        return GetType() == other.GetType() && Id.Equals(other.Id);
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as Entity);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}