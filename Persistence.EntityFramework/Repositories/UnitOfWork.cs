using Infrastructure.Repository;
using Persistence.EntityFramework.Database;
using System;
using System.Data.Entity;
using System.Data;

namespace Persistence.EntityFramework.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext _dbContext;
        private bool _disposed = false;
        public UnitOfWork(IObjectContextFactory dbContext)
        {
            if (dbContext == null) throw new ArgumentNullException("Unit of Work");

            _dbContext = dbContext.Init();
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }

        #region Transactions
        public void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Unspecified)
        {
            if (_dbContext.Database.Connection.State != ConnectionState.Open)
            {
                _dbContext.Database.Connection.Open();
            }

            _dbContext.Database.BeginTransaction(isolationLevel);
        }

        public bool Commit()
        {
            _dbContext.Database.CurrentTransaction?.Commit();
            return true;
        }

        public void RollBack()
        {
            _dbContext.Database.CurrentTransaction?.Rollback();
        }
        #endregion  

        #region Dispose
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }

        public virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                if (_dbContext != null)
                {
                    if (_dbContext.Database.Connection.State == ConnectionState.Open)
                    {
                        _dbContext.Database.Connection.Close();
                    }

                    _dbContext.Dispose();
                    _dbContext = null;

                    _disposed = true;
                }
            }
        }


        #endregion  
    }
}
