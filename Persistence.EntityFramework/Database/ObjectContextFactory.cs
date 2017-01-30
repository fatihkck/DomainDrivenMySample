using System.Data.Entity;

namespace Persistence.EntityFramework.Database
{
    public class ObjectContextFactory : IObjectContextFactory
    {
        private DbContext _context;
        public DbContext Init()
        {
            return _context ?? (_context = new MyDatabaseContext());
        }

        public DbContext Init(DbContext context)
        {
            _context = context;

            return _context;
        }
    }
}
