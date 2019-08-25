using System;
using System.Linq;
using System.Linq.Expressions;

namespace InsightConsulting.Domain.Interfaces
{
    public interface IRepository<T> where T : class, new()
    {
        IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);
        IQueryable<T> All();
        int Count();
        void Detach(T entity);
        T GetSingle(int? id);
        T GetSingle(Expression<Func<T, bool>> predicate);
        T GetSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        IQueryable<T> FromSqlProc(string sql, params object[] parameters);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void DeleteWhere(Expression<Func<T, bool>> predicate);
        void Commit();
    }
}
