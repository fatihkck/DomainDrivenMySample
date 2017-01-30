using Infrastructure.Domain;
using Infrastructure.Repository;
using Persistence.EntityFramework.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Persistence.EntityFramework.Repositories
{
    public abstract class Repository<Entity, IdType> : IRepository<Entity, IdType> where Entity : class, IEntity
    {

        private readonly DbContext _context;
        
        public Repository(IObjectContextFactory contextFactory)
        {
            if (contextFactory == null) throw new ArgumentNullException("Database Context");

            _context = contextFactory.Init();
        }

        public Entity FindBy(IdType id)
        {
            return _context.Set<Entity>().Find(id);
        }

        public IEnumerable<Entity> GetAll()
        {
            return _context.Set<Entity>();
        }

        public void Add(Entity entity)
        {
           _context.Set<Entity>().Add(entity);
        }

        public void AddRange(IEnumerable<Entity> entities)
        {
            _context.Set<Entity>().AddRange(entities);
        }

        public void Update(Entity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;

        }

        public void Remove(Entity entity)
        {
            _context.Set<Entity>().Remove(entity);

        }

        public void RemoveRange(IEnumerable<Entity> entities)
        {
            _context.Set<Entity>().RemoveRange(entities);
        }
    }
}
