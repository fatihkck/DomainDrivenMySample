using Infrastructure.Domain;
using System;
using System.Data;

namespace Infrastructure.Repository
{
    public interface IUnitOfWork: IDisposable
    {
        int SaveChanges();
        void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Unspecified);
        bool Commit();
        void RollBack();
    }
}
