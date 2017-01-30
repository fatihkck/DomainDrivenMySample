using System.Data.Entity;

namespace Persistence.EntityFramework.Database
{
    public interface IObjectContextFactory
    {
        DbContext Init();
        DbContext Init(DbContext context);
    }
}
