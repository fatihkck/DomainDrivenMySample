using Infrastructure.Domain;
using System.Collections.Generic;

namespace Infrastructure.Repository
{
    public interface IRepository<Entity,IdType>
        :IReadOnlyRepository<Entity,IdType> where Entity
        :class, IEntity
    {

        void Add(Entity entity);
        void AddRange(IEnumerable<Entity> entities);
        void Update(Entity entity);
        void Remove(Entity entity);
        void RemoveRange(IEnumerable<Entity> entities);

    }
}
