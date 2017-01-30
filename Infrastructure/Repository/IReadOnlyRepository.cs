using Infrastructure.Domain;
using System.Collections.Generic;

namespace Infrastructure.Repository
{
    public interface IReadOnlyRepository<Entity,IdType> where Entity:IEntity
    {
        Entity FindBy(IdType id);
        IEnumerable<Entity> GetAll();
        
    }
}
