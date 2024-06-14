using Dominus.Database;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Dominus.BusinessLogic
{
    public class DomainLogic<T> where T : BaseEntityCustom
    {

        public virtual T Add(T data)
        {
            try
            {
                BeginTransaction();
                if (!HasErrors)
                {
                    data = UnitOfWork.Repository<T>().Add(data);
                }
                else
                    throw GetBusinessExeption();
                return data;
            }
            catch (Exception)
            {
                RollbackTransaction();
                throw;
            }
            finally
            {
                CommitTransaction();
            }
        }

        public virtual T Modify(T data)
        {
            try
            {
                BeginTransaction();
                if (!HasErrors)
                    data = UnitOfWork.Repository<T>().Modify(data);
                else
                    throw GetBusinessExeption();
                return data;
            }
            catch (Exception)
            {
                RollbackTransaction();
                throw;
            }
            finally
            {
                CommitTransaction();
            }
        }

        public virtual T Remove(T data)
        {
            try
            {
                BeginTransaction();
                if (!HasErrors)
                    data = UnitOfWork.Repository<T>().Remove(data);
                else
                    throw GetBusinessExeption();
                return data;
            }
            catch (Exception)
            {
                RollbackTransaction();
                throw;
            }
            finally
            {
                CommitTransaction();
            }
        }

        public virtual T FindById(Expression<Func<T, bool>> predicate)
        {
            return FindById(predicate, false);
        }

        public virtual T FindById(Expression<Func<T, bool>> predicate, bool include = false)
        {
            try
            {
                T data;
                if (!HasErrors)
                    data = UnitOfWork.Repository<T>().FindById(predicate, include);
                else
                    throw GetBusinessExeption();
                return data;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public virtual T FindById(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool disableTracking = true)
        {
            try
            {
                T data;
                if (!HasErrors)
                    data = UnitOfWork.Repository<T>().FindById(predicate, orderBy, include, disableTracking);
                else
                    throw GetBusinessExeption();
                return data;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Task<List<T>> FindAllAsync(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return UnitOfWork.Repository<T>().FindAllAsync(predicate, null, null, true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual List<T> FindAll(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return UnitOfWork.Repository<T>().FindAll(predicate, null, null, true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<List<T>> FindAllAsync(Expression<Func<T, bool>> predicate, bool include = false)
        {
            try
            {
                return UnitOfWork.Repository<T>().FindAllAsync(predicate, include);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual List<T> FindAll(Expression<Func<T, bool>> predicate, bool include = false)
        {
            return UnitOfWork.Repository<T>().FindAll(predicate, include);
        }

        public Task<List<T>> FindAllAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            try
            {
                return UnitOfWork.Repository<T>().FindAllAsync(predicate, null, include, true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual List<T> FindAll(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            try
            {
                return UnitOfWork.Repository<T>().FindAll(predicate, null, include, false);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<List<T>> FindAllAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool disableTracking = true)
        {
            try
            {
                return UnitOfWork.Repository<T>().FindAllAsync(predicate, orderBy, include, disableTracking);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual List<T> FindAll(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool disableTracking = true)
        {
            try
            {
                return UnitOfWork.Repository<T>().FindAll(predicate, orderBy, include, disableTracking);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual List<TResult> FindAll<TResult>(Expression<Func<T, TResult>> selector, Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool disableTracking = true) where TResult : class
        {
            try
            {
                return UnitOfWork.Repository<T>().FindAll(selector, predicate, orderBy, include, disableTracking);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual List<TResult> FindAll<TResult>(Expression<Func<T, TResult>> selector, Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, int index = 0, int size = 20, bool disableTracking = true) where TResult : class
        {
            try
            {
                return UnitOfWork.Repository<T>().FindAll(selector, predicate, orderBy, include, disableTracking);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<T1> ExecuteQuerySql<T1>(string sql, List<DataBaseParameter> parametros)
        {
            return UnitOfWork.Repository<T>().ExecuteQuerySql<T1>(sql, parametros);
        }

        /// <summary>
        /// Permite ejecutar una consulta SQL y convertirla en una lista de objetos
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <param name="sp"></param>
        /// <param name="parametros"></param>
        /// <returns></returns>
        public List<T1> ExecuteQuerySpSql<T1>(string sql, List<DataBaseParameter> parametros)
        {
            return UnitOfWork.Repository<T>().ExecuteQuerySpSql<T1>(sql, parametros);
        }

        public Dictionary<string, object> ExecuteSqlCommand(string comandoSql, List<DataBaseParameter> parametros)
        {
            return UnitOfWork.Repository<T>().ExecuteSqlCommand(comandoSql, parametros);
        }

        public Dictionary<string, object> ExecuteStoreProcedure(string nombreProcedimiento, List<DataBaseParameter> parametros)
        {
            return UnitOfWork.Repository<T>().ExecuteStoreProcedure(nombreProcedimiento, parametros);
        }

        public Dictionary<string, object> ExecuteStoreProcedureDictionary(string nombreProcedimiento, List<DataBaseParameter> parametros)
        {
            return UnitOfWork.Repository<T>().ExecuteStoreProcedureDictionary(nombreProcedimiento, parametros);
        }

        public IQueryable<T> Table(bool include = false)
        {
            return UnitOfWork.Repository<T>().GetTable(include);
        }

        public List<Dictionary<string, object>> EjecutarConsultaDiccionario(string sql, List<DataBaseParameter> parametros)
        {
            return UnitOfWork.Repository<T>().ExecuteQueryDictionary(sql, parametros);
        }


        #region Error Properties and Methods

        private List<string> exeptionMessages;

        public List<string> ExeptionMessages
        {
            get
            {
                if (exeptionMessages == null)
                    exeptionMessages = new List<string>();
                return exeptionMessages;
            }
            set
            {
                exeptionMessages = value;
            }
        }

        public bool HasErrors
        {
            get
            {
                return ExeptionMessages.Count > 0;
            }
        }

        public void AddExeptionMessages(string message, params string[] args)
        {
            ExeptionMessages.Add(String.Format(message, args));
        }

        public string GetFormatMessage(string message, params string[] args)
        {
            return string.Format(message, args);
        }

        public Exception GetBusinessExeption()
        {
            string mensajesError = "Business Rules \n";
            foreach (string mensaje in ExeptionMessages)
                mensajesError += mensaje + " \n";
            return new Exception(mensajesError);
        }

        #endregion

        #region Transactional Properties and Methods


        public bool CommitTheTransaction { get; set; }

        public UnitOfWork UnitOfWork { get; protected set; }

        public void CommitTransaction()
        {
            if (CommitTheTransaction)
                UnitOfWork.CommitTransaction();
        }

        public void RollbackTransaction()
        {
            if (CommitTheTransaction)
                UnitOfWork.RollbackTransaction();
        }

        public void BeginTransaction()
        {
            UnitOfWork.BeginTransaction();
        }

        #endregion
    }
}

