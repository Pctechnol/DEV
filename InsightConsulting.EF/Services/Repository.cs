using InsightConsulting.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace InsightConsulting.EF.Services
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly InsightConsultingDbContext _context;

        public Repository(InsightConsultingDbContext context)
        {
            _context = context;
        }

        public virtual IQueryable<T> All()
        {
            return _context.Set<T>();
        }

        public void Detach(T entity)
        {
            var result = _context.Set<T>().FirstOrDefault();
            var entry = _context.Entry(entity);
            entry.State = EntityState.Detached;
        }
        public virtual int Count()
        {
            return _context.Set<T>().Count();
        }

        public virtual IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public T GetSingle(int? id)
        {
            return _context.Set<T>().FirstOrDefault();
        }

        public T GetSingle(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().FirstOrDefault(predicate);
        }

        public T GetSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();

            foreach (var includeProperty in includeProperties)
                query = query.Include(includeProperty);

            return query.Where(predicate).FirstOrDefault();
        }

        public IQueryable<T> FromSqlProc(string sql, params object[] parameters)
        {
            return _context.Set<T>().FromSql(sql, parameters);
        }

        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public virtual void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public virtual void Update(T entity)
        {
            var entry = _context.Entry(entity);
            entry.State = EntityState.Modified;
        }
        public virtual void Delete(T entity)
        {
            var entry = _context.Entry(entity);
            entry.State = EntityState.Deleted;
        }

        public virtual void DeleteWhere(Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> entities = _context.Set<T>().Where(predicate);

            foreach (var entity in entities)
            {
                var entry = _context.Entry(entity);
                entry.State = EntityState.Deleted;
            }
        }

        public virtual void Commit()
        {
            _context.SaveChanges();
        }
    }
}
