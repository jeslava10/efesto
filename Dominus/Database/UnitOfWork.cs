using System;
using Microsoft.EntityFrameworkCore.Storage;

namespace Dominus.Database
{
	public class UnitOfWork
	{
        public DataBaseSetting Settings { get; protected set; }

        private IDbContextTransaction transaction;

        public DContext DbContext { get; protected set; }

        public UnitOfWork(DataBaseSetting confg)
        {
            Settings = confg;
            DbContext = new DContext(confg);
        }

        public UnitOfWork(DContext confg)
        {
            DbContext = confg;
        }

        public void BeginTransaction()
        {
            if (transaction == null)
                transaction = DbContext.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            if (transaction != null)
            {
                transaction.Commit();
                transaction = null;
            }
        }

        public void RollbackTransaction()
        {
            if (transaction != null)
            {
                transaction.Rollback();
                transaction = null;
            }
        }

        public BaseRepository<T> Repository<T>() where T : BaseEntityCustom
        {
            return new BaseRepository<T>(this);
        }

    }
}

